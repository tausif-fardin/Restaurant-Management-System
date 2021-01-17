using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using MetroFramework.Forms;

namespace RestaurantManagementSystem
{
    public partial class UserCustomisation : MetroForm
    {
        private DataAccess Da { set; get; }
        private DataSet Ds { set; get; }
        private string Query { set; get; }

        public UserCustomisation()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
            this.IdGenerate();
        }

        private bool IsValidToAdd()
        {
            if (String.IsNullOrEmpty(this.txtUserId.Text) || String.IsNullOrEmpty(this.txtUserName.Text) || String.IsNullOrEmpty(this.txtPassword.Text) || String.IsNullOrEmpty(this.txtAddress.Text) || String.IsNullOrEmpty(this.cmbRole.Text))

            {
                return false;
            }

            else
            {
                return true;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool decision = this.IsValidToAdd();

                if (decision)
                {
                    this.Query = @"select * from User_Table where id = '" + this.txtUserId.Text + "';";
                    DataTable dt = this.Da.ExecuteQueryTable(this.Query);

                    if (dt.Rows.Count == 0)
                    {
                        this.Query = @"insert into User_Table values ('" + this.txtUserId.Text + "','" + this.txtUserName.Text + "','" + this.txtPassword.Text + "','" + this.txtAddress.Text + "','" + this.cmbRole.Text + "');";
                        int row = this.Da.ExecuteUpdateQuery(this.Query);

                        if (row == 1)
                            MessageBox.Show("User added successfully.");
                        else
                            MessageBox.Show("Something went wrong");

                        this.PopulateGridView();
                    }

                    else if (dt.Rows.Count == 1)
                    {
                        this.Query = @"update User_Table set name ='" + this.txtUserName.Text + "', password ='" + this.txtPassword.Text + "', address = '" + this.txtAddress.Text + "', role = '" + this.cmbRole.Text + "' where id = '" + this.txtUserId.Text +"';";
                        int row = this.Da.ExecuteUpdateQuery(this.Query);

                        if (row == 1)
                            MessageBox.Show("User Information updated successfully");
                        else
                            MessageBox.Show("User Information update failed.");

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

        private void IdGenerate()
        {
            this.Query = "select * from User_Table order by id desc";
            this.Ds = this.Da.ExecuteQuery(this.Query);

            string previousId = this.Ds.Tables[0].Rows[0][0].ToString();
            string[] temp = previousId.Split('A');
            int serialNo = Convert.ToInt32(temp[1]);
            string nextId = "A" + (++serialNo).ToString("000");
            this.txtUserId.Text = nextId;

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
            UserDetails userDetail = new UserDetails();
            userDetail.Visible = true;
        }

        private void PopulateGridView(string sql = "select * from User_Table;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);
            this.dgvUserCustomisation.AutoGenerateColumns = false;
            this.dgvUserCustomisation.DataSource = this.Ds.Tables[0];
        }

        private void txtAutoSearch_TextChanged(object sender, EventArgs e)
        {
            this.Query = @"select * from User_Table where name like '" + this.txtAutoSearch.Text + "%';";
            this.PopulateGridView(this.Query);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.dgvUserCustomisation.CurrentRow.Cells[0].Value.ToString();
                string name = this.dgvUserCustomisation.CurrentRow.Cells[1].Value.ToString();

                this.Query = @"delete from User_Table where id = '" + id + "';";
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

        private void dgvUserCustomisation_DoubleClick(object sender, EventArgs e)
        {
            this.txtUserId.Text = this.dgvUserCustomisation.CurrentRow.Cells["id"].Value.ToString();
            this.txtUserName.Text = this.dgvUserCustomisation.CurrentRow.Cells["name"].Value.ToString();
            this.txtPassword.Text = this.dgvUserCustomisation.CurrentRow.Cells["password"].Value.ToString();
            this.cmbRole.Text = this.dgvUserCustomisation.CurrentRow.Cells["role"].Value.ToString();
            this.txtAddress.Text = this.dgvUserCustomisation.CurrentRow.Cells["address"].Value.ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.IdGenerate();
            this.txtUserName.Text = "";
            this.txtPassword.Text = "";
            this.txtAddress.Text = "";
        }
    }
}
