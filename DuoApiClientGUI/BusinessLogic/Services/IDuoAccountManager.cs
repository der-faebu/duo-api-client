using System.Collections.Generic;
using System.Threading.Tasks;
using DuoApiClientGUI.Models;

namespace DuoApiClientGUI.BusinessLogic
{
    public interface IDuoAccountManager
    {
        IEnumerable<DuoAccount> Accounts { get; set; }
        void LoadAccounts(bool awaitData);
        void AddAccount(string name);
        void OpenAccount();
        void RemoveAccount(string accountId);
        Task LoadUsers(string accountId);
    }
}