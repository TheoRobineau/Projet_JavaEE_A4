using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend
{
    public class bdd
    {
        
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FF4UVH8;Initial Catalog=Users;Integrated Security=True");
        public void getdata(string username, string password)
        {
            string query = "Select Count(*) From UserList where Username ='" + username + "' and UserPassword ='" + password + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                System.Diagnostics.Debug.WriteLine("c'est bon");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("c'est pas bon");
            }
        }
        public void update(string username, string password)
        {
            string query = "Select Count(*) From UserList where Username ='" + username + "' and UserPassword ='" + password + "'";
            SqlDataAdapter sdb = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            sdb.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                System.Diagnostics.Debug.WriteLine("c'est bon");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("c'est pas bon");
            }
        }
    }


    
}