using System.Collections.Frozen;
using M3UManager;
using M3UManager.Models;
using MediatR;
using Microsoft.Extensions.Options;
using tivi.Models;

public static partial class SyncTivi
{
  public record Request() : IRequest;

  class Handler(IMediator mediator, IOptions<TiviOptions> options) : IRequestHandler<Request>
  {
    public async Task Handle(Request request, CancellationToken cancellationToken)
    {
      var m3uTask = mediator.Send(new GetM3UPlaylist.Request(), cancellationToken);
      var xmltvTask = mediator.Send(new GetXmlTvPlaylist.Request(), cancellationToken);

      await Task.WhenAll(m3uTask, xmltvTask);
      var m3UReader = await m3uTask;
      var epg = await xmltvTask;

      var channelsByCategory = m3UReader.Channels
        //.Where(z => countryCodes.Contains(GetCountryCode(z)))
        .GroupBy(MatchCategory)
        .ToDictionary(z => z.Key, z => z.ToList());
      var locals = channelsByCategory[RecordCategory.Local];
      var us = channelsByCategory[RecordCategory.UnitedStates];

      foreach (var local in locals.AsEnumerable().Reverse())
      {
        if (AllowedLocals.Any(v => local.Title.Contains(v, StringComparison.OrdinalIgnoreCase)))
        {
          us.Insert(0, new()
          {
            Duration = local.Duration,
            GroupTitle = "┃USA┃ LOCAL	",
            Logo = local.Logo,
            MediaUrl = local.MediaUrl,
            Title = local.Title,
            TvgID = local.TvgID,
            TvgName = local.TvgName,
          });
        }
      }

      var resultsDirectory = options.Value.ResultsDirectory;
      if (!Directory.Exists(resultsDirectory))
      {
        Directory.CreateDirectory(resultsDirectory);
      }

      foreach (var (category, channels) in channelsByCategory.Where(z => z.Key > 0))
      {
        var newm3U = new M3U()
        {
          HasEndList = m3UReader.HasEndList,
          MediaSequence = m3UReader.MediaSequence,
          PlayListType = m3UReader.PlayListType,
          TargetDuration = m3UReader.TargetDuration,
          Version = m3UReader.Version,
          Channels = [..channels]
        };
        var channelsToCopy = channels.Where(z => !string.IsNullOrWhiteSpace(z.TvgID)).Select(z => z.TvgID).Distinct();
        var xmlChannels = epg.Channel.Join(channelsToCopy, z => z.Id, z => z, (a, _) => a).ToList();
        var newepg = new Tv()
        {
          Date = epg.Date,
          Generatorinfoname = epg.Generatorinfoname,
          Generatorinfourl = epg.Generatorinfourl,
          Sourcedataurl = null,
          Sourceinfoname = category.ToString(),
          Sourceinfourl = null,
          Programme = [.. xmlChannels.SelectMany(channel => epg.Programme.Where(z => z.Channel == channel.Id))],
          Channel = xmlChannels,
        };

        newm3U.SaveM3U(Path.Combine(resultsDirectory, $"{category}.m3u").ToLowerInvariant(), M3UType.AttributesType);
        newepg.Save(Path.Combine(resultsDirectory, $"{category}.xml").ToLowerInvariant());
      }
    }

    RecordCategory MatchCategory(M3UManager.Models.Channel channel)
    {
      var groupTags =
        channel.GroupTitle.Split(['┃'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
      if (groupTags is [_, var mid, ..] &&
          MidTagsToIgnore.Any(x => mid.Contains(x, StringComparison.OrdinalIgnoreCase)))
      {
        return 0;
      }

      var titleTags =
        channel.Title.Split(['┃'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
      if (titleTags is [_, var mid2, ..] &&
          MidTagsToIgnore.Any(x => mid2.Contains(x, StringComparison.OrdinalIgnoreCase)))
      {
        return 0;
      }

      var mediaExtension = Path.GetExtension(channel.MediaUrl);
      if (mediaExtension is ".mp4" or ".mkv" or ".avi")
      {
        return RecordCategory.MovieAndSeries;
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

      if (g is not (RecordCategory.Canada or RecordCategory.UnitedStates or RecordCategory.UnitedKingdom or RecordCategory.NewZealand or RecordCategory.Australia))
      {
        return g;
      }

      var mediaUrl = new Uri(channel.MediaUrl);
      if (
        mediaUrl.AbsolutePath.StartsWith("/movie", StringComparison.OrdinalIgnoreCase)
        || mediaUrl.AbsolutePath.StartsWith("/series", StringComparison.OrdinalIgnoreCase)
        || mediaUrl.AbsolutePath.Contains("/MOVIES & SERIES/", StringComparison.OrdinalIgnoreCase)
      )
      {
        return RecordCategory.MovieAndSeries;
      }

      return g;
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
        ["UK", "BASIC TV+" or "INDIA EU" or "RAKUTEN TV" or "F1 TV PRO" or "BEIN SPORTS"] => RecordCategory.Skipped,
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


    private static readonly HashSet<string> AllowedLocals = new(StringComparer.OrdinalIgnoreCase)
    {
      "Raleigh", "Durham", "Chapel Hill", "WAXN", "WBTV", "WCCB", "WCNC", "WCTI", "WCWG", "WFPX", "WGHP", "WGPX",
      "WITN", "WJZY", "WLOS", "WNCN", "WPXU", "WRAY", "WRDC", "WRPX", "WSKY", "WSOC", "WTVD", "WTVI", "WUNC", "WUND",
      "WUNE", "WUNF", "WUNG", "WUNL", "WUNM", "WUNP", "WUNU", "WUNW", "WUVC", "WYCW", "WWIW", "WWAY", "WVEB", "WTWL",
      "WSAV", "WRTD-CD", "WQDH", "WIRP", "WILM", "WIDO", "WGTB", "WDRH", "WDMC", "WDKT", "WCEE", "WAUG", "WACN",
      "WYBE", "WUBX", "WTMV", "WTGC", "WSOC", "WPEM", "WNGT", "WNCR", "WNCB", "WJGC", "WHWD", "WHFL", "WHEH", "WGSR",
      "WDRN", "WECT", "WEPX", "WFMY", "WLFL", "WMYV", "WNCT", "WRAL", "WRAZ", "WSFX", "WUNJ", "WUNK", "WWAY", "WXLV",
      "WYDO"
    };
  }
}
