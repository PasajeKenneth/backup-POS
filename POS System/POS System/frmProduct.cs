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
using System.Collections;

namespace POS_System
{
    public partial class frmProduct : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        frmProductList flist;
        DBConnection dbcon = new DBConnection();

        public frmProduct(frmProductList frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            flist = frm;
        }
        public void LoadCategory()
        {
            comboBox2.Items.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT category FROM tblCategory", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }
        public void LoadBrand()
        {
            comboBox1.Items.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT brand FROM tblBrand", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Clear()
        {
            txtPrice.Clear();
            txtPdesc.Clear();
            txtPcode.Clear();
            txtBarcode.Clear();
            comboBox1.SelectedIndex = -1; // Reset to no selection
            comboBox2.SelectedIndex = -1; // Reset to no selection
            txtPcode.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPcode.Text) || string.IsNullOrWhiteSpace(txtPdesc.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to save this product?", "Save Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string bid = "", cid = "";
                    cn.Open();

                    // Get Brand ID
                    cm = new SqlCommand("SELECT id FROM tblBrand WHERE brand = @brand", cn);
                    cm.Parameters.AddWithValue("@brand", comboBox1.Text);
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        bid = dr["id"].ToString();
                    }
                    dr.Close();

                    // Get Category ID
                    cm = new SqlCommand("SELECT id FROM tblCategory WHERE category = @category", cn);
                    cm.Parameters.AddWithValue("@category", comboBox2.Text);
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        cid = dr["id"].ToString();
                    }
                    dr.Close();

                    // Insert Product
                    cm = new SqlCommand("INSERT INTO tblProduct (pcode, barcode, pdesc, bid, cid, price, reorder) VALUES (@pcode, @barcode, @pdesc, @bid, @cid, @price, @reorder)", cn);
                    cm.Parameters.AddWithValue("@pcode", txtPcode.Text);
                    cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cm.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                    cm.Parameters.AddWithValue("@bid", bid);
                    cm.Parameters.AddWithValue("@cid", cid);
                    cm.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                    cm.Parameters.AddWithValue("@reorder", int.Parse(txtReorder.Text));
                    cm.ExecuteNonQuery();

                    MessageBox.Show("Product has been successfully saved.");
                    Clear();
                    flist.LoadRecords();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close(); // Ensure the connection is closed
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPcode.Text) || string.IsNullOrWhiteSpace(txtPdesc.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to update this product?", "Update Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string bid = "", cid = "";
                    cn.Open();

                    // Get Brand ID
                    cm = new SqlCommand("SELECT id FROM tblBrand WHERE brand = @brand", cn);
                    cm.Parameters.AddWithValue("@brand", comboBox1.Text);
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        bid = dr["id"].ToString();
                    }
                    dr.Close();

                    // Get Category ID
                    cm = new SqlCommand("SELECT id FROM tblCategory WHERE category = @category", cn);
                    cm.Parameters.AddWithValue("@category", comboBox2.Text);
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        cid = dr["id"].ToString();
                    }
                    dr.Close();

                    // Update Product
                    cm = new SqlCommand("UPDATE tblProduct SET barcode = @barcode, pdesc = @pdesc, bid = @bid, cid = @cid, price = @price, reorder = @reorder WHERE pcode = @pcode", cn);
                    cm.Parameters.AddWithValue("@pcode", txtPcode.Text);
                    cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cm.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                    cm.Parameters.AddWithValue("@bid", bid);
                    cm.Parameters.AddWithValue("@cid", cid);
                    cm.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                    cm.Parameters.AddWithValue("@reorder", int.Parse(txtReorder.Text));
                    cm.ExecuteNonQuery();

                    MessageBox.Show("Product has been successfully updated.");
                    Clear();
                    flist.LoadRecords();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close(); // Ensure the connection is closed
            }
        }
    }
}
