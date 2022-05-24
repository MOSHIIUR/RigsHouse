using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Drawing;

namespace RigsHouse
{
    class Cproduct
    {
        internal string id { get; set; }
        internal string name { get; set; }
        internal string buyerName { get; set; }
        internal int Rprice { get; set; }
        internal int Sprice { get; set; }
        internal int discount { get; set; }
        internal string category { get; set; }
        internal string unit { get; set; }
        internal string Ustatus { get; set; }
        internal Image pic { set; get; }
        internal string description { get; set; }
        internal string cartStatus { get; set; }

        connectionString cs = new connectionString();

        SqlConnection con = new SqlConnection(connectionString.cs());



        public void getInfo(string Id)
        {
            try
            {
                string query = "select * from product where id=('" +Id+ "')"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);
                //  object returnValue;


                con.Open();
                //   returnValue = passing.ExecuteScalar();

                SqlDataAdapter sd = new SqlDataAdapter(passing);
                DataTable data = new DataTable();
                sd.Fill(data);

                id = data.Rows[0]["id"].ToString();
                name = data.Rows[0]["name"].ToString();
                Rprice = Convert.ToInt32(data.Rows[0]["Rprice"].ToString());
                discount = Convert.ToInt32(data.Rows[0]["discount"].ToString());
                category = data.Rows[0]["category"].ToString();
                unit = (data.Rows[0]["unit"].ToString());
                description = data.Rows[0]["description"].ToString();

                byte[] img = (byte[])data.Rows[0]["Picture"];
                pic = GetPhoto(img);
                Sprice = (Rprice - ((Rprice * discount) / 100));


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        public int cart(string Username, int unit)
     {
            int a = 0;
            try
            {

                string query = "insert into cart values (@Username, @ID, @Name, @unit, @price, @status, @Picture, @Ustatus)";
                SqlCommand passing = new SqlCommand(query, con);

                passing.Parameters.AddWithValue("@Username", Username);
                passing.Parameters.AddWithValue("@ID", id);
                passing.Parameters.AddWithValue("@Name", name);
                passing.Parameters.AddWithValue("@unit", unit);
                passing.Parameters.AddWithValue("@price", Sprice);
                passing.Parameters.AddWithValue("@Picture", SavePhoto(pic));
                passing.Parameters.AddWithValue("@status", 1);
                passing.Parameters.AddWithValue("@Ustatus", 0);



                con.Open(); 

                a = passing.ExecuteNonQuery();

                con.Close();
                



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (a==1) return 1;
            else return 0;


      }

   
        public void getCartStatus()
        {
            try
            {
                string query = "select * from cart where id=@id"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);
                //  object returnValue;
                passing.Parameters.AddWithValue("@id", id);


                con.Open();
                //   returnValue = passing.ExecuteScalar();

                SqlDataAdapter sd = new SqlDataAdapter(passing);
                DataTable data = new DataTable();
                sd.Fill(data);
                passing.ExecuteNonQuery();

                                
                if (data.Rows.Count.Equals(1))
                {
                    cartStatus = "1";
                }
                else
                {
                    cartStatus = "0";
                }
                con.Close();





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        public bool buyItem(string Username, int unit)
        {
            bool flag = false;
            int price = unit * Sprice;
            try
            {

                string query = "insert into buy (Username, ID, Name, unit, price, purchaseDate) values (@Username, @ID, @Name, @unit, @price, @date)";
                SqlCommand passing = new SqlCommand(query, con);

                passing.Parameters.AddWithValue("@Username", Username);
                passing.Parameters.AddWithValue("@ID", id);
                passing.Parameters.AddWithValue("@Name", name);
                passing.Parameters.AddWithValue("@unit", unit);
                passing.Parameters.AddWithValue("@price", price);
                passing.Parameters.AddWithValue("@date", "2020-12-19");



                con.Open();
                int a = passing.ExecuteNonQuery();


                if (a > 0)
                {
                    MessageBox.Show("Purchase Successfull.", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = true;
                    
                }
                else
                {
                    MessageBox.Show("Unsuccessful","Please Try again");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (flag == true) return true;
            else return false;

        }

        public int deleteCart(string id)
        {
            int a = 0;

            try
            {
                string query = "delete from cart where id=@id";
                SqlCommand passing = new SqlCommand(query, con);

                //now we are going to tell what are this @id, @name????
                passing.Parameters.AddWithValue("@id", id);



                con.Open(); //opening the connection
                a = passing.ExecuteNonQuery(); //execute query
                                                  
                

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (a == 1) return 1;
            else return 0;


        }

        public void find(int i, string category)
        {
            try
            {
                string query = "select * from product where category=('" + category + "')"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);
                //  object returnValue;


                con.Open();
                //   returnValue = passing.ExecuteScalar();

                SqlDataAdapter sd = new SqlDataAdapter(passing);
                DataTable data = new DataTable();
                sd.Fill(data);

                id = data.Rows[i]["id"].ToString();
                name = data.Rows[i]["name"].ToString();
                Rprice = Convert.ToInt32(data.Rows[i]["Rprice"].ToString());
                discount = Convert.ToInt32(data.Rows[i]["discount"].ToString());
                category = data.Rows[i]["category"].ToString();
                unit = (data.Rows[i]["unit"].ToString());
                description = data.Rows[i]["description"].ToString();

                byte[] img = (byte[])data.Rows[i]["Picture"];
                pic = GetPhoto(img);

                Sprice = (Rprice - ((Rprice * discount) / 100));

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cartList(string username, int i)
        {
            try
            {
                string query = "select * from cart where username=@username"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);
                //  object returnValue;
                passing.Parameters.AddWithValue("@username", username);


                con.Open();
                //   returnValue = passing.ExecuteScalar();

                SqlDataAdapter sd = new SqlDataAdapter(passing);
                DataTable data = new DataTable();
                sd.Fill(data);

                id = data.Rows[i]["ID"].ToString();
                name = data.Rows[i]["Name"].ToString();
                unit = (data.Rows[i]["unit"].ToString());
                byte[] img = (byte[])data.Rows[i]["Picture"];
                pic = GetPhoto(img);

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cartInfo(string id)
        {
            try
            {
                string query = "select * from cart where id=@id"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);
                //  object returnValue;
                passing.Parameters.AddWithValue("@id", id);


                con.Open();
                //   returnValue = passing.ExecuteScalar();

                SqlDataAdapter sd = new SqlDataAdapter(passing);
                DataTable data = new DataTable();
                sd.Fill(data);

                this.id = data.Rows[0]["ID"].ToString();
                name = data.Rows[0]["Name"].ToString();
                unit = (data.Rows[0]["unit"].ToString());
                Ustatus = (data.Rows[0]["Ustatus"].ToString());
                Sprice = Convert.ToInt32(data.Rows[0]["Price"].ToString());
                
                byte[] img = (byte[])data.Rows[0]["Picture"];
                pic = GetPhoto(img);

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public int getColumn(string category)
        {
            bool flag = false; int row = 0;
            try
            {
               
                string query = "select * from product where category=('" + category + "')"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);

                    con.Open();

                    SqlDataAdapter sd = new SqlDataAdapter(passing);
                    DataTable data = new DataTable();
                    sd.Fill(data);

                    row = data.Rows.Count;
               


                    con.Close();
                    //MessageBox.Show(col.ToString());
                    


                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return row;

        }


        public int getRow(string username)
        {
            int row = 0;
            try
            {
               
                string query = "select * from cart where Username=@username"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);
                passing.Parameters.AddWithValue("@username", username);


                con.Open();

                    SqlDataAdapter sd = new SqlDataAdapter(passing);
                    DataTable data = new DataTable();
                    sd.Fill(data);

                    row = data.Rows.Count;
               


                con.Close();
                    //MessageBox.Show(col.ToString());
                    


                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return row;
            

        }

        public void updateCart(string unit)
        {
            try
            {
                if (unit != "0")
                {
                    //don't miss to pass the mf "cs" that is how you are creating the connection string

                    string query = "update cart set unit=@unit where id=@id";
                    SqlCommand passing = new SqlCommand(query, con);

                    //now we are going to tell what are this @id, @name????
                    passing.Parameters.AddWithValue("@id", id);
                    passing.Parameters.AddWithValue("@unit", unit);



                    con.Open(); //opening the connection
                    int a = passing.ExecuteNonQuery(); //execute query
                                                       //sending me a value 0 or 1, if greater than 0 then insertion happend


                    if (a > 0)
                    {
                        MessageBox.Show("Data Update Successfully");
                        
                    }
                    else
                    {
                        MessageBox.Show("Data Not Updated");
                    }

                    con.Close();

                }

                else MessageBox.Show("At least one unit of product needs to be selected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void findBuyer()
        {
            try
            {
                string query = "select Username from buy where id=@id";
                SqlCommand sda = new SqlCommand(query, con);
                sda.Parameters.AddWithValue("@id", id);

                con.Open();

                SqlDataAdapter sd = new SqlDataAdapter(sda);
                DataTable data = new DataTable();
                sd.Fill(data);
                 buyerName = data.Rows[0]["Username"].ToString();


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }


}
