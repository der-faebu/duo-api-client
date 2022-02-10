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

            // Views
            var toolbarView = new ToolBarView();
            var accountsView = new AccountsView();
            accountsView.Tag = new DuoAccountsPresenter(accountsView);

            // commands
            var commands = new IToolbarCommand[]
            {
                new AddAccountCommand(messageBoxDisplayService, accountManager, configuration),
                new RefreshAccountsCommand(messageBoxDisplayService, accountManager, configuration),
                new RemoveAccountCommand(messageBoxDisplayService, accountManager, configuration,accountsView)
            };

            var mainForm = new MainForm(accountsView, toolbarView);
            mainForm.Tag = new MainFormPresenter(mainForm, accountManager);
            mainForm.Tag = new ToolbarPresenter(toolbarView, commands);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            // Application.Run(new AdminsForm(adminCreds, request, authHeaderService));
            Application.Run(mainForm);
        }
    }
}
