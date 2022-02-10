using DuoApiClientGUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoApiClientGUI.Events
{
    internal class AccountsLoadedMessage : IApplicationEvent
    {
        public DuoAccount[] Accounts { get; private set; }
        public AccountsLoadedMessage(DuoAccount[] accounts)
        {
            Accounts = accounts;
        }
    }
}
