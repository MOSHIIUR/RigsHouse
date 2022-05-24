using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace RigsHouse
{
    public partial class sellResponse : Form
    {
        SqlConnection con = new SqlConnection(connectionString.cs());

        string username; user a = new user(); Cuproduct p = new Cuproduct();
        public sellResponse(string Name, string serial)
        {
            InitializeComponent();  this.username = Name;
            p.getInfo(serial);
            pictureBox1.Image = p.pic00;
            pictureBox2.Image = p.pic01;

            productName.Text = p.name;
            label7.Text = p.Username;
            label8.Text = p.price+ "৳";
            richTextBox1.Text = p.description;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageSell a = new manageSell(username);
            a.Show();

        }

        private void sellResponse_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //don't miss to pass the mf "cs" that is how you are creating the connection string

                string query = "insert into used (Username, Name, Category, Price,  description, Picture00, picture01, status) values(@Username, @Name, @Category, @Price,  @description, @Picture00, @picture01, @status)";
                SqlCommand passing = new SqlCommand(query, con);

                //now we are going to tell what are this @id, @name????
                passing.Parameters.AddWithValue("@Username", p.Username);
                passing.Parameters.AddWithValue("@name", p.name);
                passing.Parameters.AddWithValue("@Category", p.category);
                passing.Parameters.AddWithValue("@Price", p.price);
                passing.Parameters.AddWithValue("@description", richTextBox1.Text);
                passing.Parameters.AddWithValue("@picture00",SavePhoto(p.pic00));
                passing.Parameters.AddWithValue("@picture01", SavePhoto(p.pic01));
                passing.Parameters.AddWithValue("@status", 1);


                con.Open(); //opening the connection
                int a = passing.ExecuteNonQuery(); //execute query
                                                   //sending me a value 0 or 1, if greater than 0 then insertion happend


                if (a > 0)
                {
                    //MessageBox.Show("Request Accepted");
                    int b = p.deleteRequest();
                    if (b > 0)
                    {
                        this.Hide();
                        manageSell c = new manageSell(username);
                        c.Show();


                    }
                    else
                    {
                        MessageBox.Show("Unsuccessful");
                    }

                }
                else
                {
                    MessageBox.Show("Unsuccessful");
                }

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int a = p.deleteRequest();
            
            if (a > 0)
            {
                this.Hide();
                manageSell b = new manageSell(username);
                b.Show();


            }
            else
            {
                MessageBox.Show("Unsuccessful");
            }
        }
    }
}
