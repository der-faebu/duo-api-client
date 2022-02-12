using System.Linq;
using DuoApiClientGUI.Models;
using DuoApiClientGUI.Models.Api;
using DuoApiClientGUI.BusinessLogic.Services.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DuoApiClientGUI.BusinessLogic.Services.Authentication
{
    public class ApiCredentialProviderService<TDuoApi> : IAuthProviderService<TDuoApi> where TDuoApi : IDuoApi
    {
        private readonly ILogger<ApiCredentialProviderService<TDuoApi>> _logger;
        private readonly IConfiguration _config;

        public ApiCredentialProviderService(ILogger<ApiCredentialProviderService<TDuoApi>> logger,
            IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public ApiClientCredentials<IDuoApi> GetCredentials<T>()
        {
            var apiString = typeof(T).Name;
            ApiClientCredentials<IDuoApi> test = _config.GetSection("Apis")
                .Get<ApiClientCredentials<IDuoApi>[]>()
                .FirstOrDefault(a => a.Name == apiString);
            return test;
        }
    }
}