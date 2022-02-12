namespace DuoApiClientGUI.Views
{
    partial class DuoUsersListView
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
            this.listUsers = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listUsers
            // 
            this.listUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listUsers.HideSelection = false;
            this.listUsers.Location = new System.Drawing.Point(0, 0);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(162, 114);
            this.listUsers.TabIndex = 0;
            this.listUsers.UseCompatibleStateImageBehavior = false;
            // 
            // DuoUsersListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listUsers);
            this.Name = "DuoUsersListView";
            this.Size = new System.Drawing.Size(162, 114);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listUsers;
    }
}
