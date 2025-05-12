using System.Text.Encodings.Web;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Rocket.Surgery.Hosting;
using Tivi;

var builder = WebApplication.CreateSlimBuilder();
builder.Services.AddHostedService<TiviBackgroundService>();
var app = await builder.ConfigureRocketSurgery();

var resultsDirectory =
    app.Services.GetRequiredService<IOptions<TiviOptions>>().Value.GetResultsDirectory().TrimEnd('/');
var fileProvider = new PhysicalFileProvider(resultsDirectory);
app
    .UseStaticFiles(new StaticFileOptions()
    {
        FileProvider = fileProvider,
        ServeUnknownFileTypes = true,
    })
    .UseDirectoryBrowser(new DirectoryBrowserOptions()
    {
        FileProvider = fileProvider,
    })
    .UseStatusCodePages()
    .UseHealthChecks("/health");

await app.RunAsync();