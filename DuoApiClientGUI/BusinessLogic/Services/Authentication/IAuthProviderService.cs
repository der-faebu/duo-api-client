using DuoApiClientGUI.Models;
using DuoApiClientGUI.Models.Api;

namespace DuoApiClientGUI.BusinessLogic.Services.Authentication
{
    public interface IAuthProviderService<TDuoApi> 
    {
        ApiClientCredentials<IDuoApi> GetCredentials<TDuoApi>();

    }
}