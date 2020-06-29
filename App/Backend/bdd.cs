using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Backend
{
    public class bdd
    {
        
        //public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FF4UVH8;Initial Catalog=Users;Integrated Security=True");
        public SqlConnection con = new SqlConnection(@"Data Source=PC-THEO;Initial Catalog=BackendDb;Integrated Security=True");

        public object MySqlHelper { get; private set; }

        public bool getUserExist(string username, string password)
        {
            bool user;
            string query = "Select Count(*) From UserList where Username ='" + username + "' and UserPassword ='" + password + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            sda.Fill(dt);
            System.Diagnostics.Debug.WriteLine(dt.Rows[0][0].ToString());
            if (dt.Rows[0][0].ToString() == "1")
            {
                user = true;
            }
            else
            {
                user = false;
            }

            return user;
        }
        public string getTokenUser(string username, string password)
        {
            string token;
            con.Open();

            SqlCommand command = new SqlCommand("Select TokenUser From UserList where Username ='" + username + "' and UserPassword ='" + password + "'", con);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    token= String.Format("{0}", reader["TokenUser"]);
                }
                else
                {
                    token = null;
                }
            }
            con.Close();
            return token;
        }

        public void insertdecrypt(string nameFile, string text, string key)
        {

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-FF4UVH8;Initial Catalog=Users;Integrated Security=True"))
            {
                String query = "INSERT INTO dbo.DecrypteText (NomFichier,TextDecrypte,TextKey) VALUES (@name,@text,@key)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", nameFile);
                    command.Parameters.AddWithValue("@text", text);
                    command.Parameters.AddWithValue("@key", key);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }
    }


    
}