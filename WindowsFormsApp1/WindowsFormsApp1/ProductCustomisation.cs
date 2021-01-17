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
    public partial class ProductCustomisation : MetroForm
    {
        private DataAccess Da { set; get; }
        private DataSet Ds { set; get; }
        private string Query { set; get; }


        public ProductCustomisation()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
            this.ProductIdGenerate();
        }

        private bool IsProductValidToAdd()
        {
            if (String.IsNullOrEmpty(this.txtProductName.Text) || String.IsNullOrEmpty(this.txtPrice.Text) || String.IsNullOrEmpty(this.cmbCategory.Text))

            {
                return false;
            }

            else
            {
                return true;
            }

        }

        private void ProductIdGenerate()
        {
            this.Query = "select * from Product_Table order by id desc";
            this.Ds = this.Da.ExecuteQuery(this.Query);

            string previousId = this.Ds.Tables[0].Rows[0][0].ToString();
            string[] temp = previousId.Split('P');
            int serialNo = Convert.ToInt32(temp[1]);
            string nextId = "P" + (++serialNo).ToString("000");
            this.txtProductId.Text = nextId;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool decision = this.IsProductValidToAdd();

                if (decision)
                {
                    this.Query = @"select * from Product_Table where id = '" + this.txtProductId.Text + "';";
                    DataTable dt = this.Da.ExecuteQueryTable(this.Query);

                    if (dt.Rows.Count == 0)
                    {
                        this.Query = @"insert into Product_Table values ('"+this.txtProductId.Text+"','" + this.txtProductName.Text + "','" + this.txtPrice.Text + "','" + this.cmbCategory.Text + "');";
                        int row = this.Da.ExecuteUpdateQuery(this.Query);

                        if (row == 1)
                            MessageBox.Show("Product added successfully.");
                        else
                            MessageBox.Show("Something went wrong");

                        this.PopulateGridView();
                    }

                    else if (dt.Rows.Count == 1)
                    {
                        this.Query = @"update Product_Table set name ='" + this.txtProductName.Text + "', price ='" + this.txtPrice.Text + "', Category = '" + this.cmbCategory.Text + "' where id = '" + this.txtProductId.Text + "';";
                        int row = this.Da.ExecuteUpdateQuery(this.Query);

                        if (row == 1)
                            MessageBox.Show("Product Information updated successfylly");
                        else
                            MessageBox.Show("Product Information update failed");

                        this.PopulateGridView();

                    }
                }
                else { MessageBox.Show("Fill all the fields"); }
            }

            catch (Exception exe)
            {
                MessageBox.Show("Error:" + exe.Message.ToString());
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Admin admin = new Admin();
            admin.Visible = true;
        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ProductDetail productDetail = new ProductDetail();
            productDetail.Visible = true;
        }

        private void PopulateGridView(string sql = "select * from Product_Table;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);
            this.dgvProductCustomisation.AutoGenerateColumns = false;
            this.dgvProductCustomisation.DataSource = this.Ds.Tables[0];
        }

        private void txtAutoSearchProduct_TextChanged(object sender, EventArgs e)
        {
            this.Query = @"select * from Product_Table where name like '" + this.txtAutoSearchProduct.Text + "%';";
            this.PopulateGridView(this.Query);
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.dgvProductCustomisation.CurrentRow.Cells[0].Value.ToString();
                string name = this.dgvProductCustomisation.CurrentRow.Cells[1].Value.ToString();

                this.Query = @"delete from Product_Table where id = '" + id + "';";
                int row = this.Da.ExecuteUpdateQuery(this.Query);

                if (row == 1)
                    MessageBox.Show(name + "has been deleted successfully");
                else
                    MessageBox.Show("Deletion failed");

                this.PopulateGridView();
            }
            catch (Exception exe)
            {
                MessageBox.Show("Error:" + exe.Message);
            }


        }

        private void dgvProductCustomisation_DoubleClick(object sender, EventArgs e)
        {
            this.txtProductId.Text = this.dgvProductCustomisation.CurrentRow.Cells["id"].Value.ToString();
            this.txtProductName.Text = this.dgvProductCustomisation.CurrentRow.Cells["name"].Value.ToString();
            this.txtPrice.Text = this.dgvProductCustomisation.CurrentRow.Cells["price"].Value.ToString();
            this.cmbCategory.Text = this.dgvProductCustomisation.CurrentRow.Cells["category"].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ProductIdGenerate();
            this.txtProductName.Text = "";
            this.txtPrice.Text = "";
            this.cmbCategory.SelectedIndex = -1;
        }
    }
}
