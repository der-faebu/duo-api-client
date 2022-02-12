using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuoApiClientGUI.Views
{
    public partial class MainForm : Form, IMainFormView
    {
        private readonly Control _accountsView;
        private readonly Control _usersListView;
        private readonly Control _accountsToolbarView;
        public MainForm(AccountsView accountsView, Control accountsToolbarView, Control usersListView)
        {
            InitializeComponent();
            this._accountsView = accountsView;
            this._usersListView = usersListView;
            this._accountsToolbarView = accountsToolbarView;

            AddControls();
        }

        public void AddControls()
        {
            mainTableLayout.Controls.Add(this._accountsToolbarView,0,0);
            mainTableLayout.Controls.Add(this._accountsView,0,1);
            mainTableLayout.Controls.Add(this._usersListView,1,1);

        }

    }
}
