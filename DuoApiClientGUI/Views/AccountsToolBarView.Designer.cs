namespace DuoApiClientGUI.Views
{
    partial class AccountsToolBarView
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonAddAccount = new System.Windows.Forms.ToolStripButton();
            this.buttonRefreshAccounts = new System.Windows.Forms.ToolStripButton();
            this.buttonRemoveAccount = new System.Windows.Forms.ToolStripButton();
            this.buttonShowAccountDetails = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.buttonAddAccount, this.buttonRefreshAccounts, this.buttonRemoveAccount, this.buttonShowAccountDetails});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(562, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonAddAccount
            // 
            this.buttonAddAccount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAddAccount.Image = global::DuoApiClientGUI.Properties.Resources.Add;
            this.buttonAddAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddAccount.Name = "buttonAddAccount";
            this.buttonAddAccount.Size = new System.Drawing.Size(23, 37);
            this.buttonAddAccount.Text = "Add CurrentAccount";
            // 
            // buttonRefreshAccounts
            // 
            this.buttonRefreshAccounts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRefreshAccounts.Image = global::DuoApiClientGUI.Properties.Resources.Refresh;
            this.buttonRefreshAccounts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRefreshAccounts.Name = "buttonRefreshAccounts";
            this.buttonRefreshAccounts.Size = new System.Drawing.Size(23, 37);
            this.buttonRefreshAccounts.Text = "Refresh Accounts";
            // 
            // buttonRemoveAccount
            // 
            this.buttonRemoveAccount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRemoveAccount.Image = global::DuoApiClientGUI.Properties.Resources.Erase;
            this.buttonRemoveAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemoveAccount.Name = "buttonRemoveAccount";
            this.buttonRemoveAccount.Size = new System.Drawing.Size(23, 37);
            this.buttonRemoveAccount.Text = "toolStripButton3";
            this.buttonRemoveAccount.ToolTipText = "Remove CurrentAccount\r\n";
            // 
            // buttonShowAccountDetails
            // 
            this.buttonShowAccountDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonShowAccountDetails.Image = global::DuoApiClientGUI.Properties.Resources.Details;
            this.buttonShowAccountDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShowAccountDetails.Name = "buttonShowAccountDetails";
            this.buttonShowAccountDetails.Size = new System.Drawing.Size(23, 37);
            this.buttonShowAccountDetails.Text = "Show CurrentAccount Details";
            // 
            // AccountsToolBarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Name = "AccountsToolBarView";
            this.Size = new System.Drawing.Size(562, 40);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonAddAccount;
        private System.Windows.Forms.ToolStripButton buttonRefreshAccounts;
        private System.Windows.Forms.ToolStripButton buttonRemoveAccount;
        private System.Windows.Forms.ToolStripButton buttonShowAccountDetails;
    }
}
