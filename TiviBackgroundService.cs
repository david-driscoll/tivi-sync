using System.Reactive.Linq;
using Humanizer;
using MediatR;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Rocket.Surgery.DependencyInjection;
using Rocket.Surgery.Extensions.Logging;
using Spectre.Console;

namespace Tivi;

public class ContentHealthCheck(IOptions<TiviOptions> options) : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = new Dictionary<string, object>();
    
        var moment = DateTimeOffset.Now;
            new DirectoryInfo(options.Value.ResultsDirectory)
                .EnumerateFiles()
                .OrderBy(z => z.Name)
                .ForEach(z =>
                {
                    result[z.Name] = new
                    {
                        z.Name,
                        Size = z.Length.Bytes().Humanize(),
                        LastUpdated = z.LastWriteTime.Humanize(dateToCompareAgainst: moment.DateTime)
                    };
                });

            return Task.FromResult(HealthCheckResult.Healthy("The last time the data was updated", result));
    }
}

public class TiviBackgroundService(IOptions<TiviOptions> options, IExecuteScoped<IMediator> executor, ILogger<TiviBackgroundService> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var _ in Observable.Interval(TimeSpan.FromSeconds(options.Value.IntervalInSeconds))
                           .StartWith(0)
                           .ToAsyncEnumerable().WithCancellation(stoppingToken))
        {
            using var __ = logger.TimeInformation("Refreshing Tivi data");
            try
            {
                await executor.Invoke((m, ct) => m.Send(new SyncTivi.Request(), ct), stoppingToken);
                var moment = DateTimeOffset.Now;
                var table = new Table();
                table.AddColumns("Name", "Size", "Modified");
                new DirectoryInfo(options.Value.ResultsDirectory)
                    .EnumerateFiles()
                    .OrderBy(z => z.Name)
                    .ForEach(z =>
                    {
                        table.AddRow(z.Name, z.Length.ToString(), z.LastWriteTime.Humanize(dateToCompareAgainst: moment.LocalDateTime));
                    });
                
                AnsiConsole.Write(table);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error refreshing Tivi data");
            }
        }
    }
}