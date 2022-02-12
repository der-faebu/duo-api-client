using DuoApiClientGUI.Models;
using DuoApiClientGUI.Models.Api;

namespace DuoApiClientGUI.BusinessLogic.Services.Authentication
{
    public interface IAuthHeaderService
    {
        string CreateAuthHeader(ApiClientCredentials<IDuoApi> credentials, IDuoApiRequest request);
    }
}