namespace DuoApiClientGUI.Views
{
    partial class AccountsView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewAccounts = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewAccounts
            // 
            this.treeViewAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewAccounts.Location = new System.Drawing.Point(0, 0);
            this.treeViewAccounts.Name = "treeViewAccounts";
            this.treeViewAccounts.Size = new System.Drawing.Size(147, 322);
            this.treeViewAccounts.TabIndex = 0;
            // 
            // AccountsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewAccounts);
            this.Name = "AccountsView";
            this.Size = new System.Drawing.Size(147, 322);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewAccounts;
    }
}
