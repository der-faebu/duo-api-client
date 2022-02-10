using DuoApiClientGUI.BusinessLogic;
using DuoApiClientGUI.BusinessLogic.Services.Authentication;
using DuoApiClientGUI.Models;
using DuoApiClientGUI.Models.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace DuoApiClientGUI
{
    public static class Startup
    {
        public static void ConfigureLogging(IHost host)
        {
            Log.Logger = new LoggerConfiguration() // initiate the logger configuration
                .ReadFrom
                .Configuration(host.Services
                    .GetService<IConfiguration>()) // connect serilog to our configuration folder
                .Enrich.FromLogContext() //Adds more information to our logs from built in Serilog 
                .CreateLogger(); //initialise the logger

            Log.Logger.Information("Application Starting");
        }

        public static IHostBuilder CreateDefaultBuilder()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app => { app.AddJsonFile("appsettings.json"); })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IAuthHeaderService, AuthHeaderService>();
                    services.AddSingleton<IAuthProviderService<IDuoApi>, ApiCredentialProviderService<IDuoApi>>();
                    services.AddTransient<IDuoApiRequest, DuoApiRequest>();
                    services.AddLogging(builder => builder.AddSerilog(dispose: true));
                });
            return host;
        }
    }
}