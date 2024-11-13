using System;
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
    public partial class frmRecords : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        string stitle = "Simple POS System";
        public frmRecords()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadRecord()
        {
            int i = 0;
            dataGridView1.Rows.Clear();

            try
            {
                cn.Open();

                string query = "SELECT TOP 10 pcode, pdesc, SUM(qty) AS qty " +
                               "FROM vwSoldItems " +
                               "WHERE sdate BETWEEN @StartDate AND @EndDate " +
                               "AND status LIKE 'Sold' " +
                               "GROUP BY pcode, pdesc " +
                               "ORDER BY qty DESC";

                // Prepare the command
                cm = new SqlCommand(query, cn);
                cm.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                cm.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dateTimePicker2.Value;

                // Execute the command
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView1.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the data reader and connection are properly closed
                dr?.Close();
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }

        public void CancelledOrders()
        {
            int i = 0;
            dataGridView5.Rows.Clear();

            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT * FROM vwCancelledOrder WHERE sdate BETWEEN @StartDate AND @EndDate", cn);
                cm.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dateTimePicker5.Value;
                cm.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dateTimePicker6.Value;

                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView5.Rows.Add(i, dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["total"].ToString(), dr["sdate"].ToString(), dr["voidby"].ToString(), dr["cancelledby"].ToString(), dr["reason"].ToString(), dr["action"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cancelled orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr?.Close();
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadRecord();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Clear();
                int i = 0;

                // Open the connection
                cn.Open();

                // Parameterized query for the first command
                string query1 = "SELECT c.pcode, p.pdesc, c.price, SUM(c.qty) AS tot_qty, SUM(c.disc) AS tot_disc, SUM(c.total) AS total " +
                                "FROM tblCart AS c " +
                                "INNER JOIN tblProduct AS p ON c.pcode = p.pcode " +
                                "WHERE c.status LIKE 'Sold' AND c.sdate BETWEEN @StartDate AND @EndDate " +
                                "GROUP BY c.pcode, p.pdesc, c.price";

                using (cm = new SqlCommand(query1, cn))
                {
                    cm.Parameters.AddWithValue("@StartDate", dateTimePicker4.Value);
                    cm.Parameters.AddWithValue("@EndDate", dateTimePicker3.Value);

                    using (dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            i++;
                            dataGridView2.Rows.Add(
                                i,
                                dr["pcode"].ToString(),
                                dr["pdesc"].ToString(),
                                double.Parse(dr["price"].ToString()).ToString("#,##0.00"),
                                dr["tot_qty"].ToString(),
                                dr["tot_disc"].ToString(),
                                double.Parse(dr["total"].ToString()).ToString("#,##0.00")
                            );
                        }
                    }
                }

                // Second SQL command for total calculation
                string query2 = "SELECT ISNULL(SUM(total), 0) FROM tblCart WHERE status LIKE 'Sold' AND sdate BETWEEN @StartDate AND @EndDate";

                using (cm = new SqlCommand(query2, cn))
                {
                    cm.Parameters.AddWithValue("@StartDate", dateTimePicker4.Value);
                    cm.Parameters.AddWithValue("@EndDate", dateTimePicker3.Value);
                    lblTotal.Text = double.Parse(cm.ExecuteScalar().ToString()).ToString("#,##0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                // Ensure the connection is properly closed
                if (cn.State == ConnectionState.Open) cn.Close();
            }
        }
        public void LoadCriticalItems()
        {
            try
            {
                dataGridView3.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("select p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.reorder , p.qty from tblProduct as p inner join tblBrand as b on p.bid =b.id inner join tblcategory as c on p.cid = c.id ", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView3.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadInventory()
        {
            int i = 0;
            dataGridView4.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.qty, p.reorder from tblProduct as p inner join tblBrand as b on p.bid =b.id inner join tblcategory as c on p.cid = c.id ", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView4.Rows.Add(i, dr["pcode"].ToString(), dr["barcode"].ToString(), dr["pdesc"].ToString(), dr["brand"].ToString(), dr["category"].ToString(), dr["price"].ToString(), dr["reorder"].ToString(), dr["qty"].ToString());
            }
            cm.CommandText = "";
            dr.Close();
            cn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport frm = new frmInventoryReport();
            frm.LoadReport();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CancelledOrders();
        }

        public void LoadStockInHistory()
        {
            int i = 0;
            dataGridView6.Rows.Clear();
            try
            {
                cn.Open();
                string query = "SELECT * FROM vwStockin WHERE CAST(sdate AS date) BETWEEN @startDate AND @endDate AND status LIKE 'Done'";
                cm = new SqlCommand(query, cn);
                cm.Parameters.AddWithValue("@startDate", dateTimePicker8.Value.Date);
                cm.Parameters.AddWithValue("@endDate", dateTimePicker7.Value.Date);

                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView6.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToShortDateString(), dr[6].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dr?.Close();
                cn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadStockInHistory();
        }
    }
}