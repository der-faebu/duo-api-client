using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ApiClientConsole // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        // private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var host = Startup.CreateDefaultBuilder().Build();
            Startup.ConfigureLogging(host);



            var myAhS = host.Services.GetService<IAuthHeaderService>();
            var authProvider = host.Services.GetService<IAuthProviderService<IDuoApi>>();

            var creds = authProvider.GetCredentials<DuoAdminApi>();
            var creds2 = authProvider.GetCredentials<DuoAccountsApi>();

            var parameters = new Dictionary<string, string>();
            // parameters.Add("name","Acme Corp");

            // IDuoApiRequest request = new DuoApiRequest(HttpMethods.GET, creds.ApiHost, $"/admin/v1/users", parameters);
            Console.WriteLine("done");
            var request = host.Services.GetService<IDuoApiRequest>();
            request.PrepareRequest(creds,HttpMethods.GET,$"/admin/v1/users", parameters);
            var header = myAhS.CreateAuthHeader(creds, request);
            var resp = await request.InvokeRequestAsync(header);
            Console.WriteLine(header);
            Console.ReadLine();
        }
    }
}