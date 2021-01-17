using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace RestaurantManagementSystem
{
    public partial class Login : MetroForm
    {
        internal DataAccess Da { get; set; }

        internal DataSet Ds { get; set; }

        internal string Sql { get; set; }

        public Login()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = @"select * from User_Table where id = '" + this.txtUserId.Text + "' and password = '" + this.txtPassword.Text + "'and role = '" + this.cmbRoles.SelectedItem + "';";
            this.Ds = this.Da.ExecuteQuery(sql);

            if (this.Ds.Tables[0].Rows.Count == 1)
            {
                if (this.cmbRoles.SelectedItem.ToString() == "Manager")
                {
                    this.Visible = false;
                    Dashboard db = new Dashboard();
                    db.Visible = true;

                }
                else if (this.cmbRoles.SelectedItem.ToString() == "Admin")
                {
                    this.Visible = false;
                    Admin admin = new Admin();
                    admin.Visible = true;
                }
                else { MessageBox.Show("Please select a Role"); }
            }
            else { MessageBox.Show("Login failed...Please enter valid User Name and Password!"); }
        }
    }
}
