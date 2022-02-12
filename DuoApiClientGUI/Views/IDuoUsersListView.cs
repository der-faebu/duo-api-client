using System.Windows.Forms;

namespace DuoApiClientGUI.Views
{
    public interface IDuoUsersListView
    {
        void SetElements(ListViewItem[] users);
    }
}