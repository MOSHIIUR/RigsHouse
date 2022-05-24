using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RigsHouse
{
    class Cuproduct
    {
        internal string id { get; set; }
        internal string name { get; set; }  //product name
        internal string Username { get; set; }  //the userPost this or you can say seller
        internal string price { get; set; }
        internal string category { get; set; }
        internal Image pic00 { set; get; }
        internal Image pic01 { set; get; }
        internal string description { get; set; }
        internal string status { get; set; }
        internal string Cstatus { get; set; }


        SqlConnection con = new SqlConnection(connectionString.cs());


        public void getInfo(string serial)
        {
            try
            {
                string query = "select * from sellItem where serial=('" + serial + "')"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);
                //  object returnValue;


                con.Open();
                //   returnValue = passing.ExecuteScalar();

                SqlDataAdapter sd = new SqlDataAdapter(passing);
                DataTable data = new DataTable();
                sd.Fill(data);

                id = data.Rows[0]["serial"].ToString();
                name = data.Rows[0]["name"].ToString();
                Username = data.Rows[0]["username"].ToString();
                price = (data.Rows[0]["price"].ToString());
                category = data.Rows[0]["category"].ToString();
                description = data.Rows[0]["description"].ToString();

                byte[] img = (byte[])data.Rows[0]["Picture00"];
                byte[] img01 = (byte[])data.Rows[0]["Picture01"];
                
                pic00 = GetPhoto(img);
                pic01 = GetPhoto(img01);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void UgetInfo(string ID) //find the information of product are accpeted
        {
            try
            {
                string query = "select * from used where id=('" +ID+ "')"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);
                //  object returnValue;


                con.Open();
                //   returnValue = passing.ExecuteScalar();

                SqlDataAdapter sd = new SqlDataAdapter(passing);
                DataTable data = new DataTable();
                sd.Fill(data);

                id = data.Rows[0]["id"].ToString();
                Username = data.Rows[0]["username"].ToString();
                name = data.Rows[0]["name"].ToString();
                price = (data.Rows[0]["price"].ToString());
                category = data.Rows[0]["category"].ToString();
                description = data.Rows[0]["description"].ToString();
                status = data.Rows[0]["status"].ToString();

                byte[] img = (byte[])data.Rows[0]["Picture00"];
                byte[] img01 = (byte[])data.Rows[0]["Picture01"];
                
                pic00 = GetPhoto(img);
                pic01 = GetPhoto(img01);


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }


        public int deleteRequest()
        {
            int flag = 0;
            try
            {
                string query = "delete from sellItem where serial=@id";
                SqlCommand passing = new SqlCommand(query, con);

                //now we are going to tell what are this @id, @name????
                passing.Parameters.AddWithValue("@id", id);



                con.Open(); //opening the connection
                int a = passing.ExecuteNonQuery(); //execute query
                                                   //sending me a value 0 or 1, if greater than 0 then insertion happend

                flag = 1;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (flag == 1) return 1;
            else return 0;

        }

        public bool buyItem(string buyername, string sellername, int unit)
        {
            bool flag = false;
           
            try
            {

                string query = "insert into buy (Username, ID, Name, unit, price) values (@Username, @ID, @Name, @unit, @price)";
                SqlCommand passing = new SqlCommand(query, con);

                passing.Parameters.AddWithValue("@Username", buyername);
                passing.Parameters.AddWithValue("@ID", id);
                passing.Parameters.AddWithValue("@Name", name);
                passing.Parameters.AddWithValue("@unit", unit);
                passing.Parameters.AddWithValue("@price", price);



                con.Open();
                int a = passing.ExecuteNonQuery();
                flag = true;


                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (flag == true) return true;
            else return false;
            

        }
        public void addSellerAccount(string username, string price)
        {
           
            try
            {

                string query = "insert into buy (Username, Sellprice) values (@Username, @Sellprice)";
                SqlCommand passing = new SqlCommand(query, con);

                passing.Parameters.AddWithValue("@Username", username);
                passing.Parameters.AddWithValue("@Sellprice", price);



                con.Open();
                int a = passing.ExecuteNonQuery();
                if (a>0)
                {
                    MessageBox.Show("Seller Account Updated.", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else
                {
                    MessageBox.Show("Unsuccessful", "Please Try again");
                }




                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            

        }

        public void updateUsedProductList()
        {
            try
            {
                string query = "update used set status=0 where id =@id";
                SqlCommand passing = new SqlCommand(query, con);

                //now we are going to tell what are this @id, @name????
                passing.Parameters.AddWithValue("@id", id);
                deleteCart();

                con.Open(); //opening the connection
                int a = passing.ExecuteNonQuery(); //execute query
                                                   //sending me a value 0 or 1, if greater than 0 then insertion happend


                con.Close();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public int deleteCart()
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
                passing.Parameters.AddWithValue("@price", price);
                passing.Parameters.AddWithValue("@Picture", SavePhoto(pic01));
                passing.Parameters.AddWithValue("@status", 1);
                passing.Parameters.AddWithValue("@Ustatus", 1);



                con.Open();
                a = passing.ExecuteNonQuery();
                
                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return a;


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
                    Cstatus = "1";
                }
                else
                {
                    Cstatus = "0";
                }
                con.Close();





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void addProduct()
        {
            try
            {
                //don't miss to pass the mf "cs" that is how you are creating the connection string

                string query = "insert into product values(@id, @name, @Rprice, @discount, @category, @unit, @picture, @description)";
                SqlCommand passing = new SqlCommand(query, con);

                //now we are going to tell what are this @id, @name????
                passing.Parameters.AddWithValue("@id", id);
                passing.Parameters.AddWithValue("@name", name);
                passing.Parameters.AddWithValue("@Rprice", price);
                passing.Parameters.AddWithValue("@discount", 0);
                passing.Parameters.AddWithValue("@category", category);
                passing.Parameters.AddWithValue("@unit", 1);
                passing.Parameters.AddWithValue("@description", description);

                passing.Parameters.AddWithValue("@picture", SavePhoto(pic00));
                //convert pic to byte



                con.Open(); //opening the connection
                int a = passing.ExecuteNonQuery(); //execute query
                                                   //sending me a value 0 or 1, if greater than 0 then insertion happend

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private byte[] SavePhoto(Image pic) //image convertion
        {
            //this is under the namespace system.IO, we need to add the geenrate
            MemoryStream ms = new MemoryStream(); //build in class, convert photo to byte
            pic.Save(ms, pic.RawFormat);
            return ms.GetBuffer();
        }

        public int getRow()
        {
            bool flag = false; int row = 0;
            try
            {

                string query = "select * from used"; //we want to see
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

        public void find(int i) //i means specifies row
        {
            try
            {
                string query = "select * from used"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);
                //  object returnValue;


                con.Open();
                //   returnValue = passing.ExecuteScalar();

                SqlDataAdapter sd = new SqlDataAdapter(passing);
                DataTable data = new DataTable();
                sd.Fill(data);

                id = data.Rows[i]["id"].ToString();
                name = data.Rows[i]["name"].ToString();
                Username = data.Rows[i]["username"].ToString();

                price = (data.Rows[i]["price"].ToString());
             //   category = data.Rows[i]["category"].ToString();
               // unit = (data.Rows[i]["unit"].ToString());
                description = data.Rows[i]["description"].ToString();

                byte[] img = (byte[])data.Rows[i]["picture00"];
                pic00 = GetPhoto(img);

                //Sprice = (Rprice - ((Rprice * discount) / 100));

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
