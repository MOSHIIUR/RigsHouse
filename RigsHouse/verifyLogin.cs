using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace RigsHouse
{
    class verifyLogin
    {
        public static int verify(string username, string pass) //making it static so that it we can access them using their class name
        {
            connectionString a = new connectionString();

            SqlConnection con = new SqlConnection(connectionString.cs());

            SqlCommand cmd = new SqlCommand("Select * from User_Info where UserName = @UserName and Password= @Password", con);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", pass);


            con.Open();


            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            cmd.ExecuteNonQuery(); 
            return dt.Rows.Count;


            con.Close();


        }
    }
}
