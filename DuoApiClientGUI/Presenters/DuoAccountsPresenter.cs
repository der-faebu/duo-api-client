using DuoApiClientGUI.Events;
using DuoApiClientGUI.Models;
using DuoApiClientGUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuoApiClientGUI.Presenters
{
    internal class DuoAccountsPresenter
    {
        private readonly IDuoAccountsView accountsView;

        public DuoAccountsPresenter(IDuoAccountsView accountsView)
        {
            this.accountsView = accountsView;
            EventAggregator.Instance.Subscribe<AccountsLoadedMessage>(m => RefreshTreeView(m.Accounts));

            //accountsView.SelectionChanged += OnSelectedAccountChanged;
        }

        private void RefreshTreeView(DuoAccount[] accounts)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (var account in accounts)
            {
                nodes.Add(new TreeNode(account.Name) { Tag = account, Name = account.Name });
            }
            accountsView.SetNodes(nodes.ToArray());
        }
        public void AddAccountToTreeView(DuoAccount account)
        {
            var accNode = new TreeNode(account.Name) { Tag = account, Name = account.Name };

            accountsView.AddNode(accNode);
        }
    }
}
