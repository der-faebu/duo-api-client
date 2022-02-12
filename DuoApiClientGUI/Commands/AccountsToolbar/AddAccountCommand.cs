using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuoApiClientGUI.BusinessLogic;
using DuoApiClientGUI.BusinessLogic.Services;
using DuoApiClientGUI.Events;
using DuoApiClientGUI.Properties;
using DuoApiClientGUI.Views;
using Microsoft.Extensions.Configuration;

namespace DuoApiClientGUI.Commands
{
    internal class AddAccountCommand : CommandBase
    {
        private readonly IMessageBoxDisplayService _messageBoxDisplayService;
        private readonly IDuoAccountManager _accountManager;
        private readonly IConfiguration _configuration;

        public AddAccountCommand(IMessageBoxDisplayService messageBoxDisplayService,
            IDuoAccountManager accountManager,
            IConfiguration configuration)
        {
            this._messageBoxDisplayService = messageBoxDisplayService;
            this._accountManager = accountManager;
            this._configuration = configuration;
            Icon = Resources.Add;
            ToolTip = "Add CurrentAccount";
        }

        public override void Execute()
        {
            var form = new NewAccountForm();
            var name = form.ShowDialog() == DialogResult.OK ? form.AccountName : null;
            _accountManager.AddAccount(name);
            _accountManager.LoadAccounts(false);
        }
    }
}
