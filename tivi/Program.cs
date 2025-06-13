using BlobHelper;
using MediatR;
using Microsoft.Extensions.Options;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.DependencyInjection;
using Rocket.Surgery.Hosting;
using Spectre.Console;
using Tivi;

var builder = Host.CreateApplicationBuilder();

var app = await builder.ConfigureRocketSurgery(contextBuilder => contextBuilder.ConfigureServices((context,
    configuration, services, token) =>
{
    BlobClient ImplementationFactory(IServiceProvider sp, object? key)
    {
        var url = configuration.GetValue<Uri>("AWS_ENDPOINT_URL_S3");
        var settings = new AwsSettings(url.ToString(), true, configuration.GetValue<string>("AWS_ACCESS_KEY_ID"), configuration.GetValue<string>("AWS_SECRET_ACCESS_KEY"), AwsRegion.USWest1, (string)key, new UriBuilder(url) { Path = "{bucket}/{key}" }.Uri.ToString());

        return new BlobClient(settings);
    }

    services.AddKeyedSingleton(Constants.ResultsBucketName, ImplementationFactory);
    services.AddKeyedSingleton(Constants.CacheBucketName, ImplementationFactory);
    return ValueTask.CompletedTask;
}));
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
//
// var moment = DateTimeOffset.Now;
// var table = new Table();
// table.AddColumns("Name", "Size", "Modified");
// new DirectoryInfo(options.Value.ResultsDirectory)
//     .EnumerateFiles()
//     .OrderBy(z => z.Name)
//     .ForEach(z =>
//     {
//         table.AddRow(z.Name, z.Length.Bytes().Humanize(), z.LastWriteTime.Humanize(dateToCompareAgainst: moment.LocalDateTime));
//     });
//                 
// AnsiConsole.Write(table);
