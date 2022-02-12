using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuoApiClientGUI.BusinessLogic.Services
{
    internal class MessageBoxDisplayService : IMessageBoxDisplayService
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }

        public DialogResult PromptOkCancel(string message, string title)
        {
           var result =  MessageBox.Show(message, title, MessageBoxButtons.OKCancel);
           return result;
        }
    }
}
