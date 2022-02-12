using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuoApiClientGUI.Models.Entities;

namespace DuoApiClientGUI.Views
{
    public partial class DuoUsersListView : UserControl, IDuoUsersListView
    {
        public DuoUsersListView()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
        }

        public void SetElements(ListViewItem[] users)
        {
            this.listUsers.Items.Clear();
            this.listUsers.Items.AddRange(users);
        }
    }
}
