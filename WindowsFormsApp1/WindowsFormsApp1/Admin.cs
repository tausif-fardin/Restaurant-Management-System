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
    public partial class Admin : MetroForm
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void tleCustomiseUser_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            UserCustomisation userCustomise = new UserCustomisation();
            userCustomise.Visible = true;
        }

        private void tleCustomiseProduct_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ProductCustomisation productCustomise = new ProductCustomisation();
            productCustomise.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Login login = new Login();
            login.Visible = true;
        }
    }
}
