using DuoApiClientGUI.Models.Api;

namespace DuoApiClientGUI.Models
{
    public class ApiClientCredentials<TDuoApi> where TDuoApi : IDuoApi
    {
        public string Name { get; set; } = typeof(TDuoApi).Name;
        public string ApiHost { get; set; }
        public string IntegrationKey { get; set; }
        public string SecretKey { get; set; }
        public string AuthMethod { get; set; }

        public ApiClientCredentials(string apiHost, string integrationKey, string secretKey,
            string authMethod)
        {
            ApiHost = apiHost;
            IntegrationKey = integrationKey;
            SecretKey = secretKey;
            AuthMethod = authMethod;
        }

        public ApiClientCredentials()
        {
            
        }
    }
}