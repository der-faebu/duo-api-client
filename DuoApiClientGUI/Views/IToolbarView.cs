using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuoApiClientGUI.Commands;

namespace DuoApiClientGUI.Views
{
    public interface IToolbarView
    {
        void SetCommands(IToolbarCommand[] commands);
    }
}
