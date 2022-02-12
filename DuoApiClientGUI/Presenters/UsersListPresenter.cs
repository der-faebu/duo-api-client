using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuoApiClientGUI.Events;
using DuoApiClientGUI.Models.Entities;
using DuoApiClientGUI.Views;

namespace DuoApiClientGUI.Presenters
{
    internal class UsersListPresenter
    {
        private readonly IDuoUsersListView _usersListView;
        public UsersListPresenter(IDuoUsersListView usersListView)
        {
            this._usersListView = usersListView;
            EventAggregator.Instance.Subscribe<UsersLoadedCompleteMessage>(m => RefreshUsers(m.Users));
 
        }
        private void RefreshUsers(IDuoUser[] users)
        {
            var usersList = new List<ListViewItem>();
            foreach (IDuoUser user in users)
            {
                usersList.Add(new ListViewItem(user.UserName));
            }
            _usersListView.SetElements(usersList.ToArray());
        }

    }
}
