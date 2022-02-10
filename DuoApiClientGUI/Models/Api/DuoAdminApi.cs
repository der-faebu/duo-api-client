using DuoApiClientGUI.Models;

namespace DuoApiClientGUI.Models.Api
{
    public class DuoAdminApi : IDuoApi
    {
        public string Name { get; set; } = "Admin API";
        public ApiClientCredentials<IDuoApi> Credentials { get; set; }
    }

    public class DuoAuthApi : IDuoApi
    {
        public string Name { get; set; } = "Auth API";
        public ApiClientCredentials<IDuoApi> Credentials { get; set; }
    }

    public class DuoAccountsApi : IDuoApi
    {
        public string Name { get; set; } = "Accounts API";
        public ApiClientCredentials<IDuoApi> Credentials { get; set; }
    }
}