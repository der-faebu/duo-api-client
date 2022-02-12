using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuoApiClientGUI.BusinessLogic;
using DuoApiClientGUI.BusinessLogic.Services;
using DuoApiClientGUI.Models;
using DuoApiClientGUI.Properties;
using DuoApiClientGUI.Views;
using Microsoft.Extensions.Configuration;

namespace DuoApiClientGUI.Commands
{
    internal class RemoveAccountCommand : CommandBase
    {
        private readonly IMessageBoxDisplayService _messageBoxDisplayService;
        private readonly IDuoAccountManager _accountManager;
        private readonly IConfiguration _configuration;
        private readonly IDuoAccountsView _accountView;

        public RemoveAccountCommand(IMessageBoxDisplayService messageBoxDisplayService,
            IDuoAccountManager accountManager,
            IConfiguration configuration,
            IDuoAccountsView accountView)
        {
            this._messageBoxDisplayService = messageBoxDisplayService;
            this._accountManager = accountManager;
            this._configuration = configuration;
            this._accountView = accountView;
            Icon = Resources.Erase;
            ToolTip = "Remove CurrentAccount";
        }

        public override void Execute()
        {
            var acc = _accountView.SelectedNode.Tag as DuoAccount;

            var result = _messageBoxDisplayService.PromptOkCancel("Do you really want to remove this account? This Action cannot be undone.", 
                "Remove Account");
            if (result == DialogResult.OK)
            {
                _accountManager.RemoveAccount(acc.AccountId);
            }


        }
    }
}
