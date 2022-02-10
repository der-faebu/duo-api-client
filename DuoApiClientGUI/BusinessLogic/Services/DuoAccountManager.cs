using DuoApiClientGUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuoApiClientGUI.BusinessLogic.Services.Authentication;
using DuoApiClientGUI.Enums;
using DuoApiClientGUI.Events;
using DuoApiClientGUI.Models.Api;
using DuoApiClientGUI.Models.ApiResponses;
using DuoApiClientGUI.Views;
using Microsoft.Extensions.Configuration;

namespace DuoApiClientGUI.BusinessLogic
{
    public class DuoAccountManager : IDuoAccountManager
    {
        private readonly ApiClientCredentials<IDuoApi> _credentials;
        private readonly IDuoApiRequest _request;
        private readonly IAuthHeaderService _authHeaderService;
        private readonly IConfiguration _config;
        public IEnumerable<DuoAccount>? Accounts { get; set; }


        public DuoAccountManager(IConfiguration config, ApiClientCredentials<IDuoApi> credentials, IDuoApiRequest request, IAuthHeaderService authHeaderService)
        {
            _authHeaderService = authHeaderService;
            _request = request;
            _credentials = credentials;
            _config = config;
            LoadAccounts(true);
        }

        public async void LoadAccounts(bool awaitData)
        {
            var parameters = _config.GetSection("Queries:AccountsApi").Get<QueryParameters[]>()
                .FirstOrDefault(p => p.Name == "GetAccounts");
            _request.PrepareRequest(_credentials, parameters);

            var header = _authHeaderService.CreateAuthHeader(_credentials, _request);
            IApiResponse response;
            if (awaitData)
            {
                response = _request.InvokeRequestAsync(header).Result;
            }
            else
            {
                response = await _request.InvokeRequestAsync(header);
            }
            var jsonString = JsonConvert.SerializeObject(response.ResponseData);

            Accounts = JsonConvert.DeserializeObject<IEnumerable<DuoAccount>>(jsonString);
            EventAggregator.Instance.Publish(new AccountsLoadedMessage(Accounts.ToArray()));

        }
        public async void AddAccount(string name)
        {
            var parameters = _config.GetSection("Queries:AccountsApi").Get<QueryParameters[]>()
                .FirstOrDefault(p => p.Name == "CreateAccount");
            parameters?.SetParameters(new []{name});
            _request.PrepareRequest(_credentials, parameters);
            var header = _authHeaderService.CreateAuthHeader(_credentials, _request);
            var response = await _request.InvokeRequestAsync(header);
            
            MessageBox.Show($"{response.Code} - {response.Message}");
            LoadAccounts(false);
        }

        public void OpenAccount()
        {
            throw new NotImplementedException();
        }

        public async void RemoveAccount(string account_id)
        {
            var parameters = _config.GetSection("Queries:AccountsApi").Get<QueryParameters[]>()
                .FirstOrDefault(p => p.Name == "DeleteAccount");
            parameters?.SetParameters(new[] { account_id });
            _request.PrepareRequest(_credentials, parameters);
            var header = _authHeaderService.CreateAuthHeader(_credentials, _request);
            var response = await _request.InvokeRequestAsync(header);

            MessageBox.Show($"{response.Code} - {response.Message}");
            LoadAccounts(false);
        }
    }
}