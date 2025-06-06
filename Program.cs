using Humanizer;
using MediatR;
using Microsoft.Extensions.Options;
using Rocket.Surgery.DependencyInjection;
using Rocket.Surgery.Hosting;
using Spectre.Console;
using Tivi;

var builder = Host.CreateApplicationBuilder();
var app = await builder.ConfigureRocketSurgery();
await app.StartAsync();
var options = app.Services.GetRequiredService<IOptions<TiviOptions>>();
try
{
    await app.Services.GetRequiredService<IExecuteScoped<IMediator>>()
        .Invoke((m, ct) => m.Send(new SyncTivi.Request(), ct));
}
catch (Exception e)
{
    AnsiConsole.WriteException(e);
}

var moment = DateTimeOffset.Now;
var table = new Table();
table.AddColumns("Name", "Size", "Modified");
new DirectoryInfo(options.Value.ResultsDirectory)
    .EnumerateFiles()
    .OrderBy(z => z.Name)
    .ForEach(z =>
    {
        table.AddRow(z.Name, z.Length.Bytes().Humanize(), z.LastWriteTime.Humanize(dateToCompareAgainst: moment.LocalDateTime));
    });
                
AnsiConsole.Write(table);
