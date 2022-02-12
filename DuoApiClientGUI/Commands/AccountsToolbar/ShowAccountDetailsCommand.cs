using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DuoApiClientGUI.BusinessLogic;
using DuoApiClientGUI.BusinessLogic.Services;
using DuoApiClientGUI.Events;
using DuoApiClientGUI.Models;
using DuoApiClientGUI.Properties;
using DuoApiClientGUI.Views;
using Microsoft.Extensions.Configuration;

namespace DuoApiClientGUI.Commands
{
    internal class ShowAccountDetailsCommand : CommandBase
    {
        private readonly IDuoAccountManager _accountManager;
        private readonly IConfiguration _configuration;
        private readonly IMessageBoxDisplayService _messageBoxDisplayService;
        private readonly IDuoAccountsView _accountView;


        public ShowAccountDetailsCommand(IMessageBoxDisplayService messageBoxDisplayService,
            IDuoAccountManager accountManager,
            IConfiguration configuration,
            IDuoAccountsView accountView)
        {
            this._accountManager = accountManager;
            this._configuration = configuration;
            this._messageBoxDisplayService = messageBoxDisplayService;
            this._accountView = accountView;
            Icon = Resources.Details;
            ToolTip = "Show CurrentAccount details.";
        }

        public async override void Execute()
        {
            Console.WriteLine("test");
            // is account or option?
            if (_accountView.SelectedNode.Parent == null)
            {
                var selectedAccount = _accountView.SelectedNode.Tag as DuoAccount;
            }

            else
            {
                var selectedAccount = _accountView.SelectedNode.Parent.Tag as DuoAccount;
                var accountId = selectedAccount.AccountId;
                
                await _accountManager.LoadUsers(accountId);
                if (selectedAccount.Users == null)
                {
                    _messageBoxDisplayService.Show($"No users have been found for account {selectedAccount.Name}");
                }
                EventAggregator.Instance.Publish(new UsersLoadedCompleteMessage(selectedAccount.Users));

            }
        }
    }
}