using DuoApiClientGUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoApiClientGUI.Events
{
    internal class DuoAccountsLoadCompleteMessage : IApplicationEvent
    {
        private readonly DuoAccount[] _DuoAccounts;
        public DuoAccountsLoadCompleteMessage(DuoAccount[] DuoAccounts)
        {
            this._DuoAccounts = DuoAccounts;
        }

        public DuoAccount[] DuoAccounts
        {
            get { return _DuoAccounts; }
        }
    }
}
