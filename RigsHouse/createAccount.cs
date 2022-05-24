using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace RigsHouse
{
    public partial class createAccount : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["pltops"].ConnectionString;


        public createAccount()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;

            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;

                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {


                if (textBox2.Text == textBox4.Text)
                {
                    SqlConnection con = new SqlConnection(cs);
                    //don't miss to pass the mf "cs" that is how you are creating the connection string

                    string query = "insert into User_Info values(@name, @gender,  @mail, @Status, @Address, @picture, @Username, @password)";
                    SqlCommand passing = new SqlCommand(query, con);

                    //now we are going to tell what are this @id, @name????
                    passing.Parameters.AddWithValue("@name", textBox3.Text);
                    passing.Parameters.AddWithValue("@gender", comboBox1.Text);
                    passing.Parameters.AddWithValue("@mail", textBox5.Text);
                    passing.Parameters.AddWithValue("@status", 2);
                    passing.Parameters.AddWithValue("@Address", textBox6.Text);

                    passing.Parameters.AddWithValue("@Username", textBox1.Text);

                    passing.Parameters.AddWithValue("@password", textBox2.Text);

                    passing.Parameters.AddWithValue("@picture", SavePhoto());
                    //convert pic to byte



                    con.Open(); //opening the connection
                    int a = passing.ExecuteNonQuery(); //execute query
                                                       //sending me a value 0 or 1, if greater than 0 then insertion happend


                    if (a > 0)
                    {
                        MessageBox.Show("Account Created Successfully");
                        this.Hide();
                        Login b = new Login();
                        b.Show();
                    }
                    else
                    {
                        MessageBox.Show("Denied. Try Again");
                    }
                }

                else MessageBox.Show("First Confirm Password!!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private byte[] SavePhoto() //image convertion
        {
            //this is under the namespace system.IO, we need to add the geenrate
            MemoryStream ms = new MemoryStream(); //build in class, convert photo to byte
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Title = "Select Image";
            img.Filter = "Image File(*.png;*.jpg;*.jpeg)| *.*";

            if (img.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox2.Image = new Bitmap(img.FileName);
            }

        }

        private void createAccount_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox2.Checked;

            switch (status)
            {
                case true:
                    textBox4.UseSystemPasswordChar = false;
                    break;

                default:
                    textBox4.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
