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
        public MainForm(AccountsView accountsView, Control toolbarView)
        {
            InitializeComponent();
            toolbarView.Dock = DockStyle.Top;
            Controls.Add(toolbarView);
            this._accountsView = accountsView;
            ShowAccountsView();
        }

        public void ShowAccountsView()
        {
            splitContainer.Panel1.Controls.Clear();
            splitContainer.Panel1.Controls.Add(this._accountsView);
        }

    }
}
