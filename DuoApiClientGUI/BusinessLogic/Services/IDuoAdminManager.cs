using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuoApiClientGUI.Models.Entities;

namespace DuoApiClientGUI.BusinessLogic.Services
{
    internal interface IDuoAdminManager
    {
        IEnumerable<DuoUser> Users { get; set; }
        void LoadUsers();
        void AddUsers();
        void OpenUsers();
        void RemoveUsers();
    }
}
