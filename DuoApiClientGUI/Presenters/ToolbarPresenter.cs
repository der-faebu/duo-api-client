using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuoApiClientGUI.Commands;
using DuoApiClientGUI.Views;

namespace DuoApiClientGUI.Presenters
{
    internal class ToolbarPresenter
    {
        public ToolbarPresenter(ToolBarView toolBarView, IToolbarCommand[] commands)
        {
            toolBarView.SetCommands(commands);
        }
    }
}
