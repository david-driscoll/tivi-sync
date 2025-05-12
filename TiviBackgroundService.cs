using System.Reactive.Linq;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Rocket.Surgery.DependencyInjection;

namespace Tivi;

public class TiviBackgroundService(IOptions<TiviOptions> options, IExecuteScoped<IMediator> executor) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var _ in Observable.Interval(TimeSpan.FromSeconds(options.Value.IntervalInSeconds))
                           .ToAsyncEnumerable().WithCancellation(stoppingToken))
        {
            await executor.Invoke((m, ct) => m.Send(new GetTivi.Request(), ct), stoppingToken);   
        }
    }
}