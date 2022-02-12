using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuoApiClientGUI.Commands;
using DuoApiClientGUI.Views;

namespace DuoApiClientGUI.Presenters
{
    internal class AccountsToolbarPresenter
    {
        public AccountsToolbarPresenter(AccountsToolBarView accountsToolBarView, IToolbarCommand[] commands)
        {
            accountsToolBarView.SetCommands(commands);
        }
    }
}
