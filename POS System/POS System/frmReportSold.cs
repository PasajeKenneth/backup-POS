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
using Microsoft.Reporting.WinForms;

namespace POS_System
{
    public partial class frmReportSold : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        frmSoldItems f;
        DateTime startDate, endDate;

        public frmReportSold(frmSoldItems frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            f = frm;
            startDate = f.dt1.Value;
            endDate = f.dt2.Value;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmReportSold_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
        


        public void LoadReport()
        {
            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report2.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                if (f.cboCashier.Text == "All Cashier")
                {
                    string sqlQuery = "SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total " + "FROM tblcart AS c " + "INNER JOIN tblproduct AS p ON c.pcode = p.pcode " + "WHERE c.status = 'Sold' AND c.sdate BETWEEN @StartDate AND @EndDate";
                    cm = new SqlCommand(sqlQuery, cn);
                    cm.Parameters.AddWithValue("@StartDate", f.dt1.Value.ToString("yyyy-MM-dd"));
                    cm.Parameters.AddWithValue("@EndDate", f.dt2.Value.ToString("yyyy-MM-dd"));
                   
                }
                else
                {
                    string sqlQuery = "SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total " + "FROM tblcart AS c " + "INNER JOIN tblproduct AS p ON c.pcode = p.pcode " + "WHERE c.status = 'Sold' AND c.sdate BETWEEN @StartDate AND @EndDate AND c.cashier = @Cashier";
                    cm = new SqlCommand(sqlQuery, cn);
                    cm.Parameters.AddWithValue("@StartDate", f.dt1.Value.ToString("yyyy-MM-dd"));
                    cm.Parameters.AddWithValue("@EndDate", f.dt2.Value.ToString("yyyy-MM-dd"));
                    cm.Parameters.AddWithValue("@Cashier", f.cboCashier.Text);
                }
                da.SelectCommand = cm;
                da.Fill(ds.Tables["dtSoldReport"]);
                cn.Close();

                ReportParameter pDate = new ReportParameter("pDate", "Date From: " + f.dt1.Value.ToShortDateString() + " To:" + f.dt2.Value.ToShortDateString());
                ReportParameter pCashier = new ReportParameter("pCashier", "Cashier: " + f.cboCashier.Text);
                ReportParameter pHeader = new ReportParameter("pHeader", "SALES REPORT");

                reportViewer1.LocalReport.SetParameters(pDate);
                reportViewer1.LocalReport.SetParameters(pCashier);
                reportViewer1.LocalReport.SetParameters(pHeader);

                ReportDataSource rptDS = new ReportDataSource("DataSet1", ds.Tables["dtSoldReport"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}