namespace RestaurantManagementSystem
{
    partial class Admin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnExit = new MetroFramework.Controls.MetroButton();
            this.btnLogout = new MetroFramework.Controls.MetroButton();
            this.tleCustomiseProduct = new MetroFramework.Controls.MetroTile();
            this.tleCustomiseUser = new MetroFramework.Controls.MetroTile();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.btnExit);
            this.metroPanel1.Controls.Add(this.btnLogout);
            this.metroPanel1.Controls.Add(this.tleCustomiseProduct);
            this.metroPanel1.Controls.Add(this.tleCustomiseUser);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(31, 70);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1005, 455);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.Location = new System.Drawing.Point(889, 416);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 34);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseSelectable = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(4, 4);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(127, 43);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseSelectable = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tleCustomiseProduct
            // 
            this.tleCustomiseProduct.ActiveControl = null;
            this.tleCustomiseProduct.Location = new System.Drawing.Point(595, 108);
            this.tleCustomiseProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tleCustomiseProduct.Name = "tleCustomiseProduct";
            this.tleCustomiseProduct.Size = new System.Drawing.Size(172, 177);
            this.tleCustomiseProduct.TabIndex = 7;
            this.tleCustomiseProduct.Text = "Customise Product";
            this.tleCustomiseProduct.UseSelectable = true;
            this.tleCustomiseProduct.Click += new System.EventHandler(this.tleCustomiseProduct_Click);
            // 
            // tleCustomiseUser
            // 
            this.tleCustomiseUser.ActiveControl = null;
            this.tleCustomiseUser.Location = new System.Drawing.Point(242, 108);
            this.tleCustomiseUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tleCustomiseUser.Name = "tleCustomiseUser";
            this.tleCustomiseUser.Size = new System.Drawing.Size(172, 177);
            this.tleCustomiseUser.TabIndex = 6;
            this.tleCustomiseUser.Text = "Customise User";
            this.tleCustomiseUser.UseSelectable = true;
            this.tleCustomiseUser.Click += new System.EventHandler(this.tleCustomiseUser_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Admin";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Admin";
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile tleCustomiseUser;
        private MetroFramework.Controls.MetroTile tleCustomiseProduct;
        private MetroFramework.Controls.MetroButton btnLogout;
        private MetroFramework.Controls.MetroButton btnExit;
    }
}