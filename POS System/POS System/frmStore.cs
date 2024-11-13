﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_System
{
    public partial class frmStore : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        public frmStore()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void LoadRecords()
        {
            cn.Open();
            cm = new SqlCommand("select * from tblStore ", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.Read())
            {
                txtStore.Text = dr["store"].ToString();
                txtAddress.Text = dr["address"].ToString();
            }
            else
            {
                txtStore.Clear();
                txtAddress.Clear();
            }
            dr.Close();
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Save Store Details", "Store Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int count;
                    cn.Open();
                    cm = new SqlCommand("select count(*) from tblStore ", cn);
                    count = int.Parse(cm.ExecuteScalar().ToString());
                    cn.Close();
                    if (count > 0)
                    {
                        cn.Open();
                        cm = new SqlCommand("update tblStore set store =@store , address = @address ", cn);
                        cm.Parameters.AddWithValue("@store", txtStore.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {
                        cn.Open();
                        cm = new SqlCommand("insert  tblStore (store, address) values (@store, @address)  ", cn);
                        cm.Parameters.AddWithValue("@store", txtStore.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();

                    }
                    MessageBox.Show("Store Details Saved Successfully", "SAVED RECORD ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStore.Clear();
                    txtAddress.Clear();
                    txtStore.Focus();


                }
            }
            catch (Exception ex) {
                cn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
