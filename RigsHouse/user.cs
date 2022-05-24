using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RigsHouse
{
    class user
    {
       
        internal string username { get; set; }
        internal string name { get; set; }
        internal string mail { get; set; }
        internal string address { get; set; }
        internal string gender { get; set; }
        internal int status { get; set; }
        internal string pass { get; set; }
        internal string Tsum { get; set; }
        internal string Ssum { get; set; }

        internal Image pic { set; get; }


        SqlConnection con = new SqlConnection(connectionString.cs());



        public void getInfo(String Username)
        {
            try
            {
                string query = "select * from User_Info where Username=('"+Username+"')"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);
                //  object returnValue;


                con.Open();
                //   returnValue = passing.ExecuteScalar();

                SqlDataAdapter sd = new SqlDataAdapter(passing);
                DataTable data = new DataTable();
                sd.Fill(data);

                name = data.Rows[0]["name"].ToString();
                username = data.Rows[0]["Username"].ToString();
                gender = data.Rows[0]["Gender"].ToString();
                mail = data.Rows[0]["Mail"].ToString();
                address = data.Rows[0]["Address"].ToString();
                status = Convert.ToInt32(data.Rows[0]["status"].ToString());
                pass = data.Rows[0]["password"].ToString();
                byte[] img = (byte[])data.Rows[0]["Picture"];
                pic = GetPhoto(img);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        


        public void changePass(string oldPass, string newPass, string confirmPass)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from User_Info where UserName= @UserName and Password= @Password", con);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", oldPass);


                con.Open();


                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                cmd.ExecuteNonQuery();

                if (dt.Rows.Count.Equals(1))
                {
                   // password = dt.Rows[0]["password"].ToString();

                    if (newPass.Equals(confirmPass))
                    {
                        updatePass(newPass);
                    }
                    else
                    {
                        MessageBox.Show("New password & Confirm Password should be same");
                    }
                }
                else
                {
                    MessageBox.Show("Old password is not right!!!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void updatePass(string newPass)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Update user_info set  Password= @Password where UserName =@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", newPass);


                cmd.ExecuteNonQuery();


                MessageBox.Show("Password changed successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int updateAcc(string Name, string Gender, string mail, string Address, Image picture)
        {
            int a = 0;
            try
            {
                string query = "update User_Info set name=@name, Gender=@gender, mail=@mail, Address=@Address, picture=@picture where UserName =@UserName";
                SqlCommand passing = new SqlCommand(query, con);

                //now we are going to tell what are this @id, @name????
                passing.Parameters.AddWithValue("@UserName", username);

                passing.Parameters.AddWithValue("@name", Name);
                passing.Parameters.AddWithValue("@gender", Gender);
                passing.Parameters.AddWithValue("@mail", mail);
                passing.Parameters.AddWithValue("@Address", Address);
                passing.Parameters.AddWithValue("@picture", SavePhoto(picture));
                //convert pic to byte



                con.Open(); //opening the connection
                a = passing.ExecuteNonQuery(); //execute query
                                                   //sending me a value 0 or 1, if greater than 0 then insertion happend


               

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return a;
        }

        private byte[] SavePhoto(Image picture) //image convertion
        {
            //this is under the namespace system.IO, we need to add the geenrate
            MemoryStream ms = new MemoryStream(); //build in class, convert photo to byte
            picture.Save(ms, picture.RawFormat);
            return ms.GetBuffer();
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        public void usages()
        {
            try
            {
                string query = "SELECT sum(price), sum(sellPrice) FROM buy where username=('" + username + "')";

                SqlCommand passing = new SqlCommand(query, con);





                con.Open();

                SqlDataAdapter sd = new SqlDataAdapter(passing);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                passing.ExecuteNonQuery();

                Tsum = dt.Rows[0][0].ToString();
                Ssum = dt.Rows[0][1].ToString();


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        public int deleteUser()
        {
            int a = 0;

            try
            {
                string query = "delete from User_Info where Username=@Username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);

                con.Open();
                a = cmd.ExecuteNonQuery();
                con.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return a;

        }
    
    
    
    }
}
