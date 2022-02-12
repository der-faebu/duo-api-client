using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuoApiClientGUI.BusinessLogic.Services
{
    internal interface IMessageBoxDisplayService
    {
        void Show(string message);
        DialogResult PromptOkCancel(string message, string title);
    }
}
