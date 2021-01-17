﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace RestaurantManagementSystem
{
    class DataAccess
    {
        private SqlConnection sqlcon;
        public SqlConnection Sqlcon
        {
            get { return this.sqlcon; }
            set { this.sqlcon = value; }
        }

        private SqlCommand sqlcom;
        public SqlCommand Sqlcom
        {
            get { return this.sqlcom; }
            set { this.sqlcom = value; }
        }

        private SqlDataAdapter sda;
        public SqlDataAdapter Sda
        {
            get { return this.sda; }
            set { this.sda = value; }
        }

        private DataSet ds;
        public DataSet Ds
        {
            get { return this.ds; }
            set { this.ds = value; }
        }

        public DataAccess()
        {
            this.Sqlcon = new SqlConnection(@"Data Source=DESKTOP-ULK5IO0\SQLEXPRESS;Initial Catalog=RestaurantManagementSystem;Integrated Security=True");
            this.Sqlcon.Open();
        }

        private void QueryText(string query)
        {
            this.Sqlcom = new SqlCommand(query, this.Sqlcon);
        }

        public DataSet ExecuteQuery(string sql)
        {
            try
            {
                this.QueryText(sql);
                this.Sda = new SqlDataAdapter(this.Sqlcom);
                this.Ds = new DataSet();
                this.Sda.Fill(this.Ds);
                return this.Ds;
            }
            catch (Exception)

            {
                return null;
            }
        }

        public DataTable ExecuteQueryTable(string sql)
        {
            this.ExecuteQuery(sql);
            if (this.Ds != null)
                return this.Ds.Tables[0];
            else
                return null;
        }

        public int ExecuteUpdateQuery(string sql)
        {
            this.QueryText(sql);
            int u = this.Sqlcom.ExecuteNonQuery();
            return u;
        }

    }
}
