using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuoApiClientGUI.Views
{
    internal interface IDuoAccountsView
    {
        TreeNode SelectedNode { get; }

        void RemoveNode(string key);
        void SelectNode(string key);
        void AddNode(TreeNode treeNode);

        event EventHandler SelectionChanged;
        void SetParentNodes(TreeNode[] nodes);
        void SetChildNodes(string[] children);

        void SetOptionsElements(TreeNode[] treenodes, TreeNode parentNode);
    }
}
