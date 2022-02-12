using DuoApiClientGUI.Models;
using DuoApiClientGUI.BusinessLogic;
using DuoApiClientGUI.Models.Api;
using DuoApiClientGUI.Presenters;
using DuoApiClientGUI.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using DuoApiClientGUI.BusinessLogic.Services;
using DuoApiClientGUI.BusinessLogic.Services.Authentication;
using DuoApiClientGUI.Commands;
using Microsoft.Extensions.Configuration;

namespace DuoApiClientGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = Startup.CreateDefaultBuilder().Build();
            Startup.ConfigureLogging(host);
            Application.SetCompatibleTextRenderingDefault(false);

            // Configuration
            var configuration = host.Services.GetService<IConfiguration>();

            // Duo specific initialisation
            var request = host.Services.GetService<IDuoApiRequest>();
            var authHeaderService = host.Services.GetService<IAuthHeaderService>();
            var authProvider = host.Services.GetService<IAuthProviderService<IDuoApi>>();
            var adminCreds = authProvider.GetCredentials<DuoAccountsApi>();

            // services
            var messageBoxDisplayService = new MessageBoxDisplayService();

            // Forms specific initialisation
            var accountManager = new DuoAccountManager(configuration, adminCreds, request, authHeaderService);
            var adminManager = new DuoAdminManager(configuration, adminCreds, request, authHeaderService);

            // Views
            var toolbarView = new AccountsToolBarView();
            var accountsView = new AccountsView();
            var usersListView = new DuoUsersListView();
            


            // commands
            var commands = new IToolbarCommand[]
            {
                new AddAccountCommand(messageBoxDisplayService, accountManager, configuration),
                new RefreshAccountsCommand(messageBoxDisplayService, accountManager, configuration),
                new RemoveAccountCommand(messageBoxDisplayService, accountManager, configuration,accountsView),
                new ShowAccountDetailsCommand(messageBoxDisplayService, accountManager, configuration,accountsView)
            };

            var mainForm = new MainForm(accountsView, toolbarView, usersListView);

            
            // tag presenters to their forms
            accountsView.Tag = new AccountPresenter(configuration,accountsView);
            mainForm.Tag = new MainFormPresenter(mainForm, accountManager);
            mainForm.Tag = new AccountsToolbarPresenter(toolbarView, commands);
            mainForm.Tag = new UsersListPresenter(usersListView);

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            // Application.Run(new AdminsForm(adminCreds, request, authHeaderService));
            Application.Run(mainForm);
        }
    }
}
