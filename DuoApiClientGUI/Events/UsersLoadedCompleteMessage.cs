using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuoApiClientGUI.Models;
using DuoApiClientGUI.Models.Entities;

namespace DuoApiClientGUI.Events
{
    internal class UsersLoadedCompleteMessage :IApplicationEvent
    {
        public IDuoUser[] Users { get; private set; }
        public UsersLoadedCompleteMessage(IDuoUser[] users)
        {
            Users = users;
        }

    }
}
