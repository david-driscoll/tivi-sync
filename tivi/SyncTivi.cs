using System.Net;
using System.Xml;
using BlobHelper;
using Humanizer;
using M3UManager;
using M3UManager.Models;
using MediatR;
using Microsoft.Extensions.Options;
using Rocket.Surgery.Extensions.Encoding;
using Rocket.Surgery.Extensions.Logging;
using Tivi.Models;
using Channel = M3UManager.Models.Channel;

namespace Tivi;

public static partial class SyncTivi
{
    public record Request() : IRequest;

    class Handler(
        [FromKeyedServices(Constants.ResultsBucketName)]
        BlobClient minioClient,
        IMediator mediator,
        IOptions<TiviOptions> options,
        IOptions<TiviProxyOptions> proxyOptions,
        ILogger<Handler> logger) : IRequestHandler<Request>
    {
        public async Task Handle(Request request, CancellationToken cancellationToken)
        {
            using var _ = logger.TimeInformation("Syncing Tivi playlists");
            var m3uTask = mediator.Send(new GetM3UPlaylist.Request(), cancellationToken);
            var xmltvTask = mediator.Send(new GetXmlTvPlaylist.Request(), cancellationToken);
            var (observer, results) = DownloadIcons(logger);

            var m3UReader = await m3uTask;

            var channelsByCategory = m3UReader.Channels
                //.Where(z => countryCodes.Contains(GetCountryCode(z)))
                .GroupBy(MatchCategory)
                .ToDictionary(z => z.Key, z => z.ToHashSet());
            var locals = channelsByCategory[RecordCategory.Local];
            var us = channelsByCategory[RecordCategory.UnitedStates];

            us.RemoveWhere(locals.Contains);

            foreach (var local in locals.AsEnumerable().Reverse())
            {
                if (!AllowedLocals.Any(v => local.Title.Contains(v, StringComparison.OrdinalIgnoreCase))) continue;
                us.Add(new()
                {
                    Duration = local.Duration,
                    GroupTitle = "┃USA┃ LOCALS",
                    Logo = local.Logo,
                    MediaUrl = local.MediaUrl,
                    Title = local.Title,
                    TvgID = local.TvgID,
                    TvgName = local.TvgName,
                });
            }

            foreach (var (category, channels) in channelsByCategory
                         .Where(z =>
                             z.Key is not
                                 (
                                 RecordCategory.MovieAndSeries or
                                 RecordCategory.PayPerView or
                                 RecordCategory.OnDemand or
                                 RecordCategory.Twenty47 or
                                 RecordCategory.FreeTv
                                 )
                         ))
            {
                logger.LogInformation("Saving {Category} with {Count} channels", category, channels.Count);
                await SaveModifiedPlaylist(category.ToString(), [category]);
            }

            await SaveModifiedPlaylist("ondemand",
                [RecordCategory.OnDemand, RecordCategory.Twenty47, RecordCategory.FreeTv]);
            await SaveModifiedPlaylist("paypreview", [RecordCategory.PayPerView]);
            await SaveModifiedPlaylist(nameof(RecordCategory.MovieAndSeries), [RecordCategory.MovieAndSeries]);

            using (logger.TimeInformation("Downloading picons"))
            {
                var icons = await results(cancellationToken);

                await minioClient.Enumerate("picons", token: cancellationToken)
                    .ToAsyncEnumerable()
                    .Expand((result, token) => ValueTask.FromResult(result.HasMore
                        ? minioClient.Enumerate("picons", result.NextContinuationToken, token).ToAsyncEnumerable()
                        : AsyncEnumerable.Empty<EnumerationResult>()))
                    .SelectMany(z => z.Blobs.ToAsyncEnumerable())
                    .Where(z =>
                    {
                        if (z.LastUpdateUtc < DateTime.Now.Subtract(TimeSpan.FromDays(1))) return true;
                        logger.LogDebug("Skipping picon {IconPath} as it is not older than 1 day", z.Key);
                        return false;
                    })
                    .Where(z => !icons.Contains(z.Key))
                    .Do(z => logger.LogDebug("Removing picon {IconPath}", z))
                    .ForEachAwaitAsync(async path => { await minioClient.Delete(path.Key, cancellationToken); },
                        cancellationToken);
            }
            // 

            async Task SaveModifiedPlaylist(string name, HashSet<RecordCategory> categories)
            {
                var channels = channelsByCategory
                    .Where(z => categories.Contains(z.Key))
                    .SelectMany(z => z.Value)
                    .OrderBy(z => z.GroupTitle)
                    .ThenBy(z => z.TvgName)
                    .ToArray();
                var newm3U = new M3U()
                {
                    HasEndList = m3UReader.HasEndList,
                    MediaSequence = m3UReader.MediaSequence,
                    PlayListType = m3UReader.PlayListType,
                    TargetDuration = m3UReader.TargetDuration,
                    Version = m3UReader.Version,
                    Channels =
                    [
                        ..channels.Select(x => new Channel()
                        {
                            Duration = x.Duration,
                            GroupTitle = x.GroupTitle,
                            Logo = observer(x.Logo),
                            MediaUrl = ReplaceUri(x.MediaUrl),
                            Title = x.Title,
                            TvgID = x.TvgID,
                            TvgName = x.TvgName,
                        })
                    ],
                };

                var epg = await xmltvTask;
                epg.Channel.Do(z => z.Icon.Do(d => d.Src = observer(d.Src)));
                epg.Programme.Do(z => z.Icon.Do(d => d.Src = observer(d.Src)));

                var xmlChannels = epg.Channel
                    .Join(channels, z => z.Id, z => z.TvgID, (a, _) => a)
                    .OrderBy(z => z.Id)
                    .ToList();
                var newepg = new Tv
                {
                    Date = epg.Date,
                    Generatorinfoname = name.Humanize(),
                    Generatorinfourl = $"{epg.Generatorinfourl}/{name}.xml",
                    Sourcedataurl = epg.Sourcedataurl,
                    Sourceinfoname = epg.Generatorinfoname,
                    Sourceinfourl = epg.Generatorinfourl,
                    Programme =
                    [
                        .. xmlChannels
                            .SelectMany(channel => epg.Programme.Where(z => z.Channel == channel.Id))
                    ],
                    Channel = xmlChannels,
                };

                using var m3UStream = new MemoryStream();
                await using var meuWriter = new StreamWriter(m3UStream, leaveOpen: true);
                await newm3U.SaveM3U(meuWriter, M3UType.TagsType);
                await meuWriter.FlushAsync(cancellationToken);
                m3UStream.Seek(0, SeekOrigin.Begin);

                await minioClient.Write($"{name}.m3u".ToLowerInvariant(), "application/x-mpegURL", m3UStream.ToArray(),
                    cancellationToken);

                using var epgStream = new MemoryStream();
                await using var epgWriter = new StreamWriter(epgStream, leaveOpen: true);
                await using var epgXmlWriter = new XmlTextWriter(epgWriter);
                newepg.Save(epgWriter);
                await epgWriter.FlushAsync(cancellationToken);
                epgStream.Seek(0, SeekOrigin.Begin);

                await minioClient.Write($"{name}.xml".ToLowerInvariant(), "application/xml", epgStream.ToArray(),
                    cancellationToken);
            }
        }


        string ReplaceUri(string uri)
        {
            var newUri = new UriBuilder(uri);
            if (proxyOptions.Value.Hostname is { } hostname)
            {
                newUri.Host = hostname;
                newUri.Port = 443;
                newUri.Scheme = "https";
            }

            if (proxyOptions.Value is { Username: { } username, Password: { } password })
            {
                var currentPath = newUri.Path.TrimStart('/');
                newUri.Path = string.Join("/", [username, password, ..currentPath.Split('/').Skip(2)]);
            }

            return newUri.ToString();
        }

        RecordCategory MatchCategory(M3UManager.Models.Channel channel)
        {
            var isMovieOrSeries = IsMovieAndSeries(channel.MediaUrl);
            var groupTags =
                channel.GroupTitle.Split(['┃'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (groupTags is [_, var mid, ..] &&
                MidTagsToIgnore.Any(x => mid.Contains(x, StringComparison.OrdinalIgnoreCase)))
            {
                return RecordCategory.Skipped;
            }

            var titleTags =
                channel.Title.Split(['┃'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (titleTags is [_, var mid2, ..] &&
                MidTagsToIgnore.Any(x => mid2.Contains(x, StringComparison.OrdinalIgnoreCase)))
            {
                return RecordCategory.Skipped;
            }

            var g = MatchTags(groupTags);
            if (g is RecordCategory.Dropped)
            {
                g = MatchTags(titleTags);
            }

            if (g is RecordCategory.Dropped or RecordCategory.Skipped)
            {
                return g;
            }

            // if (g is not (RecordCategory.Canada or RecordCategory.UnitedStates or RecordCategory.UnitedKingdom
            //     or RecordCategory.NewZealand or RecordCategory.Australia))
            // {
            //     return isMovieOrSeries ? RecordCategory.OnDemand : g;
            // }

            return isMovieOrSeries ? RecordCategory.OnDemand : g;
        }

        static bool IsMovieAndSeries(string url)
        {
            var mediaExtension = Path.GetExtension(url);
            if (mediaExtension is ".mp4" or ".mkv" or ".avi")
            {
                return true;
            }

            var mediaUrl = new Uri(url);
            if (
                mediaUrl.AbsolutePath.StartsWith("/movie", StringComparison.OrdinalIgnoreCase)
                || mediaUrl.AbsolutePath.StartsWith("/series", StringComparison.OrdinalIgnoreCase)
                || mediaUrl.AbsolutePath.Contains("/MOVIES & SERIES/", StringComparison.OrdinalIgnoreCase)
            )
            {
                return true;
            }

            return false;
        }

        static RecordCategory MatchTags(string[] tags)
        {
            var countryCategory = GetCountryCategory(tags);
            return (countryCategory, tags) switch
            {
                // on demand
                // ppv
                (_, ["PPV", ..]) => RecordCategory.PayPerView,
                (_, [_, [.., 'P', 'P', 'V'] or [.., '(', 'P', 'P', 'V', ')'] or ['P', 'P', 'V', ..]]) => RecordCategory
                    .PayPerView,
                (RecordCategory.Dropped or RecordCategory.Skipped, _) => countryCategory,
                (_, [_, "NEWS NETWORK"]) => RecordCategory.UnitedStates,
                (_, [_, [.., ' ', 'N', 'E', 'T', 'W', 'O', 'R', 'K']]) => RecordCategory.Local,
                (_, [_, "CW & MY"]) => RecordCategory.Local,
                (_, [_, "KIDS | BABY" or "KIDS"]) => RecordCategory.Kids,
                (_, [_, "24/7 | SHOWS" or "24/7 | ACTORS" or "24/7 | PLUTO"]) => RecordCategory.Twenty47,
                (_, [_, ['O', 'D', ' ', ..]]) => RecordCategory.OnDemand,
                //		(_, [_, "CINEMA"]) => Category.Cinema,
                //		(_, [_, "AMAZON PRIME"]) => Category.AmazonPrime,
                //		(_, [_, "APPLE TV+"]) => Category.AppleTvPlus,
                //		(_, [_, "NETFLIX"]) => Category.Netflix,
                //		(_, [_, "DISNEY+"]) => Category.DisneyPlus,
                //		(_, [_, "HULU"]) => Category.Hulu,
                (_, [_, "PEACOCK"]) => RecordCategory.FreeTv,
                (_, [_, "TUBI"]) => RecordCategory.FreeTv,
                (_, [_, "PLUTO"]) => RecordCategory.FreeTv,

                _ => countryCategory,
            };
        }

        static RecordCategory GetCountryCategory(string[] tags)
        {
            return tags switch
            {
                ["ES", ..] => RecordCategory.Skipped,
                ["AR", ..] => RecordCategory.Skipped,
                ["CA EN", ..] => RecordCategory.Canada,
                ["IE", "IRELAND 4K"] => RecordCategory.UnitedKingdom,
                ["IE", ..] => RecordCategory.Skipped,
                ["NZ", ..] => RecordCategory.NewZealand,
                ["AU", ..] => RecordCategory.Australia,
                ["UK", "BASIC TV+" or "INDIA EU" or "RAKUTEN TV" or "F1 TV PRO" or "BEIN SPORTS"] => RecordCategory
                    .Skipped,
                ["UK", ..] => RecordCategory.UnitedKingdom,
                ["US" or "USA", ..] => RecordCategory.UnitedStates,
                _ => RecordCategory.Dropped,
            };
        }

        private static readonly HashSet<string> MidTagsToIgnore =
        [
            "PREMIER", "Sport", "Football", "Event", "CHAMPIONSHIP", "LEAGUE", "ESPN+", "TEAMS", "FLORUGBY", "SPECTRUM",
            "RACING", "WWE", "TENNIS", "BTN+", "SOCCER", "UFC 24/7", "ESPN", "NBA ", "MLB ", "NFL ", "COLLEGE", "FLO ",
            "NCAAF ", "MLS ", "MILB", "SHOPPING", "SPFL REPLAY", "MUSIC", "LATIN", "HALLMARK", " REPLAY ⏺", " REPLAY",
            "BET+", "UFC & FITE", "DIRTVISION"
        ];

        private (Func<string, string> proxyIcon, Func<CancellationToken, Task<HashSet<string>>> results) DownloadIcons(
            ILogger logger)
        {
            var client = new HttpClient();
            var items = new HashSet<(string source, string cachePath, string proxyUrl)>();

            string ProxyIconFunc(string url)
            {
                if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || uri.Host == "image.tmdb.org") return url;

                var uriBuilder = new UriBuilder(uri);
                var builder = new UriBuilder()
                {
                    Host = proxyOptions.Value.Hostname, Port = 443, Scheme = "https",
                    Path = Path.Combine(["picons", uriBuilder.Host, ..uriBuilder.Path.Split('/')])
                };
                var cachePath = Path.Combine(["picons", uriBuilder.Host, ..uriBuilder.Path.Split('/')]);
                items.Add((url, cachePath, builder.ToString()));

                return builder.ToString();
            }

            async Task<HashSet<string>> Icons(CancellationToken ct)
            {
                var foundIcons = new HashSet<string>();
                await foreach (var item in items.ToAsyncEnumerable()
                                   .SelectAwait(async (z) =>
                                       await DownloadIcon(z.source, z.cachePath, CancellationToken.None)
                                           ? z.cachePath
                                           : null)
                                   .Buffer(10)
                                   .WithCancellation(ct))
                {
                    item.Where(z => z != null).ForEach(s => foundIcons.Add(s!));
                }

                return foundIcons;
            }

            async Task<bool> DownloadIcon(string url, string cachePath, CancellationToken ct)
            {
                if (!Uri.TryCreate(url, UriKind.Absolute, out _))
                {
                    return false;
                }

                try
                {
                    var stream = await client.GetByteArrayAsync(url, ct);
                    var cacheName = cachePath; // Base3264Encoding.EncodeString(EncodingType.Base32Url, cachePath);

                    if (await minioClient.ExistsAsync(cacheName, ct) is { } stat &&
                        DateTime.Now.Subtract(TimeSpan.FromDays(1)) < stat.LastUpdateUtc)
                    {
                        logger.LogTrace("Icon already exists in cache {Path}", cachePath);
                        return false;
                    }

                    logger.LogInformation("Downloading {Url} to {Path}", url, cachePath);
                    await minioClient.Write(cacheName, "image/png", stream, ct);
                    return true;
                }
                catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    logger.LogWarning(ex, "Icon not found {Url}", url);
                }
                catch (Exception ex)
                {
                    logger.LogWarning(ex, "Other problem downloading {Url}", url);
                }

                return false;
            }

            return (ProxyIconFunc, Icons);
        }


        private static readonly HashSet<string> AllowedLocals = new(StringComparer.OrdinalIgnoreCase)
        {
            "Raleigh", "Durham", "Chapel Hill", "WAXN", "WBTV", "WCCB", "WCNC", "WCTI", "WCWG", "WFPX", "WGHP", "WGPX",
            "WITN", "WJZY", "WLOS", "WNCN", "WPXU", "WRAY", "WRDC", "WRPX", "WSKY", "WSOC", "WTVD", "WTVI", "WUNC",
            "WUND",
            "WUNE", "WUNF", "WUNG", "WUNL", "WUNM", "WUNP", "WUNU", "WUNW", "WUVC", "WYCW", "WWIW", "WWAY", "WVEB",
            "WTWL",
            "WSAV", "WRTD-CD", "WQDH", "WIRP", "WILM", "WIDO", "WGTB", "WDRH", "WDMC", "WDKT", "WCEE", "WAUG", "WACN",
            "WYBE", "WUBX", "WTMV", "WTGC", "WSOC", "WPEM", "WNGT", "WNCR", "WNCB", "WJGC", "WHWD", "WHFL", "WHEH",
            "WGSR",
            "WDRN", "WECT", "WEPX", "WFMY", "WLFL", "WMYV", "WNCT", "WRAL", "WRAZ", "WSFX", "WUNJ", "WUNK", "WWAY",
            "WXLV",
            "WYDO"
        };
    }
}
