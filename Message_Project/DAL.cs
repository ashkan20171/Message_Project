using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace Message_Project
{
    public class DAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        public string constring = "Data Source=BEHNAM;Initial Catalog=MsgDB;Integrated Security=True";

        public DAL()
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            da = new SqlDataAdapter();
            con.ConnectionString = constring;
            cmd.Connection = con;
            da.SelectCommand = cmd;

        }
        public void Connect()
        {
            con.Open();
        }
        public void Disconnect()
        {
            con.Close();

        }

        public SqlDataReader reader(string Query)
        {
            cmd.CommandText = Query;

            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public void docommand(string Query)
        {
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();

        }
        public int GetOne(string Query)
        {
            cmd.CommandText = Query;
            int x;
            object obj = cmd.ExecuteScalar();
            x = Convert.ToInt32(obj);
            return x;
        }
      
    }
}