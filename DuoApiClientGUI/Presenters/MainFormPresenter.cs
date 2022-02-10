using DuoApiClientGUI.BusinessLogic;
using DuoApiClientGUI.Events;
using DuoApiClientGUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoApiClientGUI.Presenters
{
    internal class MainFormPresenter
    {
        private readonly IDuoAccountManager _accountsManager;
        public MainFormPresenter(IMainFormView mainFormView, IDuoAccountManager accountsManager)
        {
            mainFormView.Load += MainFormViewOnLoad;
            //mainFormView.FormClosed += MainFormViewOnFormClosed;
            //mainFormView.HelpRequested += OnHelpRequested;
            //mainFormView.KeyUp += MainFormViewOnKeyUp;

            _accountsManager = accountsManager; 
        }

        

        private void MainFormViewOnLoad(object sender, EventArgs eventArgs)
        {
            ReloadAccounts();
        }

        private void ReloadAccounts()
        {
            EventAggregator.Instance.Publish(new AccountsLoadedMessage(_accountsManager.Accounts.ToArray()));
            EventAggregator.Instance.Publish(new DuoAccountsLoadCompleteMessage(_accountsManager.Accounts.ToArray()));

        }
    }
}
