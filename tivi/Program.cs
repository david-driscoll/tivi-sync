using Humanizer;
using MediatR;
using Microsoft.Extensions.Options;
using Minio;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.DependencyInjection;
using Rocket.Surgery.Hosting;
using Spectre.Console;
using Tivi;

var builder = Host.CreateApplicationBuilder();

var app = await builder.ConfigureRocketSurgery(contextBuilder => contextBuilder.ConfigureServices((context,
    configuration, services, token) =>
{
    services.AddSingleton(sp =>
    {
        var factory = new MinioClientFactory(client =>client
            .WithSSL(false)
            .WithEndpoint($"{configuration.GetValue<Uri>("AWS_ENDPOINT_URL_S3").Host}:{configuration.GetValue<Uri>("AWS_ENDPOINT_URL_S3").Port}")
        
            .WithCredentials(configuration.GetValue<string>("AWS_ACCESS_KEY_ID"),
                configuration.GetValue<string>("AWS_SECRET_ACCESS_KEY")));
        var client = factory.CreateClient();

        configuration.AsEnumerable().Where(z => z.Key.StartsWith("AWS_") && z.Value is { Length: > 0 })
            .ForEach(x => AnsiConsole.WriteLine($"{x.Key}:   {x.Value}"));
        // TODO:     use the fancy method at some point
        typeof(MinioConfig).GetProperty("ServiceProvider")?.SetValue(client.Config, sp);
        return client;
    });
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
