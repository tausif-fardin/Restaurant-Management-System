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
    public partial class Dashboard : MetroForm
    {
        internal DataAccess Da { get; set; }

        internal DataSet Ds { get; set; }

        internal string Sql { get; set; }

        internal double totalBill = 0;

        public Dashboard()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        private void PopulateMetroGridViewItemList(string sql = @"select * from Product_Table;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);
            this.mgvProductNames.AutoGenerateColumns = false;
            this.mgvProductNames.DataSource = this.Ds.Tables[0];
        }


        private void btnExitDashboard_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCategories.SelectedItem.ToString() == "Burger")
            {
                this.Sql = @"select * from Product_Table where category='Burger';";
                this.PopulateMetroGridViewItemList(this.Sql);
            }
            else if (this.cmbCategories.SelectedItem.ToString() == "Beverages")
            {
                this.Sql = @"select * from Product_Table where category='Beverages';";
                this.PopulateMetroGridViewItemList(this.Sql);
            }
            else if (this.cmbCategories.SelectedItem.ToString() == "Combo")
            {
                this.Sql = @"select * from Product_Table where category='Combo';";
                this.PopulateMetroGridViewItemList(this.Sql);
            }
            else if (this.cmbCategories.SelectedItem.ToString() == "Curry")
            {
                this.Sql = @"select * from Product_Table where category='Curry';";
                this.PopulateMetroGridViewItemList(this.Sql);
            }
            else if (this.cmbCategories.SelectedItem.ToString() == "Kabab & Grill")
            {
                this.Sql = @"select * from Product_Table where category='Kabab&Grill';";
                this.PopulateMetroGridViewItemList(this.Sql);
            }
            else if (this.cmbCategories.SelectedItem.ToString() == "Pizza")
            {
                this.Sql = @"select * from Product_Table where category='Pizza';";
                this.PopulateMetroGridViewItemList(this.Sql);
            }
            else if (this.cmbCategories.SelectedItem.ToString() == "Sandwich")
            {
                this.Sql = @"select * from Product_Table where category='Sandwich';";
                this.PopulateMetroGridViewItemList(this.Sql);
            }
        }

        private void mgvProductNames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var name = this.mgvProductNames.CurrentRow.Cells["name"].Value.ToString();
                this.txtItemName.Text = name;
                var price = this.mgvProductNames.CurrentRow.Cells["price"].Value.ToString();
                this.txtPrice.Text = price;
                this.txtDiscount.Text = "0";

            }
            catch (Exception exc1)
            {
                MessageBox.Show(exc1.Message);
            }
        }
        
        private void btnAddToCart_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.txtTotal.Text != null && this.nudQuantity.Value != 0)
                {
                    int count = mgvCart.Rows.Add();
                    mgvCart.Rows[count].Cells[0].Value = this.txtItemName.Text;
                    mgvCart.Rows[count].Cells[1].Value = this.txtTotal.Text;
                    totalBill = totalBill + Convert.ToDouble(this.txtTotal.Text);
                    this.txtTotalBill.Text = totalBill.ToString();
                    this.txtItemName.Clear();
                    this.txtPrice.Clear();
                    this.txtTotal.Clear();
                    this.nudQuantity.ResetText();
                }
                else
                {
                    MessageBox.Show("Please select an item to order.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you. Have a nice Day.");
            this.mgvCart.Rows.Clear();
            this.txtTotalBill.Clear();
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Sql = @"select * from Product_Table where category ='" + this.cmbCategories.SelectedItem.ToString() + "' and name like '" + this.txtSearchItem.Text + "%';";
                this.PopulateMetroGridViewItemList(this.Sql);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                int qnt = int.Parse(nudQuantity.Value.ToString());
                int price = int.Parse(this.txtPrice.Text);
                double total = (qnt * price);


                double discountedPrice = total - (total * (Double.Parse(this.txtDiscount.Text) / 100));
                this.txtTotal.Text = discountedPrice.ToString();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Login login = new Login();
            login.Visible = true;
        }
    }
}
