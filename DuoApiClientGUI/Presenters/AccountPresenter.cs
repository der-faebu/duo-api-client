using DuoApiClientGUI.Events;
using DuoApiClientGUI.Models;
using DuoApiClientGUI.Views;
using System.Collections.Generic;
using System.Windows.Forms;
using DuoApiClientGUI.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace DuoApiClientGUI.Presenters
{
    internal class AccountPresenter
    {
        private readonly IDuoAccountsView _accountsView;
        private readonly IConfiguration _config;
        private string[] _accountOptions;
        public AccountPresenter(IConfiguration config, IDuoAccountsView accountsView)
        {
            this._config = config;
            this._accountsView = accountsView;

            _accountOptions = _config.GetSection("AccountOptions").Get<string[]>();
            
            EventAggregator.Instance.Subscribe<AccountsLoadedMessage>(m => RefreshTreeView(m.Accounts));
        }

        private void SetAccountSettings(string[] accountOptions)

        {
            _accountOptions = accountOptions;
        }

        private void RefreshTreeView(DuoAccount[] accounts)
        {
            List<TreeNode> parentNodes = new List<TreeNode>();
            foreach (var account in accounts)
            {
                parentNodes.Add(new TreeNode(account.Name) { Tag = account, Name = account.Name });
            }
            _accountsView.SetParentNodes(parentNodes.ToArray());
            _accountsView.SetChildNodes(_accountOptions);
        }
    }
}
