using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuoApiClientGUI.BusinessLogic.Services.Authentication;
using DuoApiClientGUI.Models;
using DuoApiClientGUI.Models.Api;
using DuoApiClientGUI.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace DuoApiClientGUI.BusinessLogic.Services
{
    internal class DuoAdminManager : IDuoAdminManager
    {
        private readonly ApiClientCredentials<IDuoApi> _credentials;
        private readonly IDuoApiRequest _request;
        private readonly IAuthHeaderService _authHeaderService;
        private readonly IConfiguration _config;

        private DuoAccount _currentAccount;

        public IEnumerable<DuoUser> Users { get; set; }
        public DuoAccount CurrentAccount { get; set; }

        public DuoAdminManager(IConfiguration config, ApiClientCredentials<IDuoApi> credentials, 
            IDuoApiRequest request, IAuthHeaderService authHeaderService)
        {
            _authHeaderService = authHeaderService;
            _request = request;
            _credentials = credentials;
            _config = config;
        }
        public void SetCurrentAccount(DuoAccount account)
        {
            this._currentAccount = account;
        }
        public void LoadUsers()
        {
            // needs :
                // request
                // header
                // account

            // Mocking users for now
            Users =  new List<DuoUser>()
            {
                new DuoUser("hampi","hampi@manser.com", "hampi",(DateTime.Now).ToShortDateString(),
                    "Manser","hampi.manser")
            };
        }

        public void AddUsers()
        {
            throw new NotImplementedException();
        }

        public void OpenUsers()
        {
            throw new NotImplementedException();
        }

        public void RemoveUsers()
        {
            throw new NotImplementedException();
        }
    }
}
