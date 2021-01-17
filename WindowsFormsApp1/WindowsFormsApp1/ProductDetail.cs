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
    public partial class ProductDetail : MetroForm
    {
        private DataAccess Da { set; get; }
        private DataSet Ds { set; get; }

        public ProductDetail()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            string query = "select * from Product_Table";
            this.PopulateGridView(query);
        }

        private void PopulateGridView(string sql)
        {
            this.Ds = this.Da.ExecuteQuery(sql);
            this.dgvProductDetail.AutoGenerateColumns = false;
            this.dgvProductDetail.DataSource = this.Ds.Tables[0];
        }

        private void btnBackProduct_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ProductCustomisation product = new ProductCustomisation();
            product.Visible = true;
        }
    }
}
