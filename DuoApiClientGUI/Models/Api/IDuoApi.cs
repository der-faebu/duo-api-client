using DuoApiClientGUI.Models;

namespace DuoApiClientGUI.Models.Api
{
    public interface IDuoApi
    {
        string Name { get; set; }
        ApiClientCredentials<IDuoApi> Credentials { get; set; }
    }
}
