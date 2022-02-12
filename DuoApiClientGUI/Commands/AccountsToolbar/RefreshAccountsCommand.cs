using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuoApiClientGUI.BusinessLogic;
using DuoApiClientGUI.BusinessLogic.Services;
using DuoApiClientGUI.Events;
using DuoApiClientGUI.Properties;
using Microsoft.Extensions.Configuration;

namespace DuoApiClientGUI.Commands
{
    internal class RefreshAccountsCommand : CommandBase
    {
        private readonly IMessageBoxDisplayService _messageBoxDisplayService;
        private readonly IDuoAccountManager _accountManager;
        private readonly IConfiguration _configuration;

        public RefreshAccountsCommand(IMessageBoxDisplayService messageBoxDisplayService,
            IDuoAccountManager accountManager,
            IConfiguration configuration)
        {
            this._messageBoxDisplayService = messageBoxDisplayService;
            this._accountManager = accountManager;
            this._configuration = configuration;
            Icon = Resources.Refresh;
            ToolTip = "Refresh Accounts";
        }

        public override void Execute()
        {
            _accountManager.LoadAccounts(false);
            EventAggregator.Instance.Publish(new AccountsLoadedMessage(_accountManager.Accounts.ToArray()));
            EventAggregator.Instance.Publish(new DuoAccountsLoadCompleteMessage(_accountManager.Accounts.ToArray()));
        }
    }
}
