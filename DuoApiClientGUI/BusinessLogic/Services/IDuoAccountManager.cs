using System.Collections.Generic;
using DuoApiClientGUI.Models;

namespace DuoApiClientGUI.BusinessLogic
{
    public interface IDuoAccountManager
    {
        IEnumerable<DuoAccount>? Accounts { get; set; }
        void LoadAccounts(bool awaitData);
        void AddAccount(string name);
        void OpenAccount();
        void RemoveAccount(string account_id);
    }
}