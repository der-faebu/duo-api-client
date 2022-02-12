using DuoApiClientGUI.BusinessLogic;
using DuoApiClientGUI.Models;
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
    public partial class AccountsView : UserControl, IDuoAccountsView
    {
        public AccountsView()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            treeViewAccounts.AfterSelect += (s, a) => OnSelectionChanged();
        }
        public TreeNode SelectedNode
        {
            get
            {
                return treeViewAccounts.SelectedNode;
            }
        }

        public void AddNode(TreeNode treeNode)
        {
            treeViewAccounts.Nodes.Add(treeNode);
        }

        public void SetParentNodes(TreeNode[] treeNodes)
        {
            treeViewAccounts.Nodes.Clear();
            treeViewAccounts.Nodes.AddRange(treeNodes);
        }

        public void SetOptionsElements(TreeNode[] treenodes, TreeNode parentNode)
        {
            parentNode.Nodes.Clear();
            parentNode.Nodes.AddRange(treenodes);
        }
        public void RemoveNode(string key)
        {
            var node = treeViewAccounts.Nodes[key];
            treeViewAccounts.Nodes.Remove(node);
        }

        public void SetChildNodes(string[] children)
        {
            foreach (TreeNode parentNode in treeViewAccounts.Nodes)
            {
                foreach (var child in children)
                {
                    parentNode.Nodes.Add(new TreeNode(child));
                }
            }
        }
        public void SelectNode(string key)
        {
            treeViewAccounts.SelectedNode = treeViewAccounts.Nodes[key];
        }

        public event EventHandler SelectionChanged;
        
        protected virtual void OnSelectionChanged()
        {
            var handler = SelectionChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

    }
}
