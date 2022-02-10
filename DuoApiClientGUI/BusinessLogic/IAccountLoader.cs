using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuoApiClientGUI.Models;

namespace DuoApiClientGUI.BusinessLogic
{
    internal interface IAccountLoader
    {
        Task LoadAccount(DuoAccount account);
    }
}
