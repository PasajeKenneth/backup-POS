﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace POS_System
{
    public class DBConnection
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public string MyConnection()
        {
            string con = @"Data Source=LAPTOP-KR07DEOP\SQLEXPRESS;Initial Catalog=POS_DEMO_DB;Integrated Security=True";
            return con;
        }
        public double GetVal()
        {
            double vat = 0;
            cn = new SqlConnection(MyConnection());

            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT * FROM tblVat", cn);
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    vat = Double.Parse(dr["vat"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                dr?.Close();
                cn?.Close();
            }

            return vat;
        }

        public string GetPassword(string user)
        {
            string password = "";
            cn = new SqlConnection(MyConnection());
            cn.Open();
            cm = new SqlCommand("select * from tblUser where username = @username", cn);
            cm.Parameters.AddWithValue("@username", user);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                password = dr["password"].ToString();
            }


            dr.Close();
            cn.Close();


            return password;
        }

    }
}
