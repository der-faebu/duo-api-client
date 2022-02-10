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
    public partial class NewAccountForm : Form
    {
        public NewAccountForm()
        {
            InitializeComponent();
        }

        public string AccountName
        {
            get { return textBox1.Text; }
        }

        private void OnButtonOkClick(object sender, EventArgs e)
        {
            string accountName = textBox1.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
