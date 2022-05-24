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
    public partial class sellProduct : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["pltops"].ConnectionString;
        string username;


        public sellProduct(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            account a = new account();
            a.Show();
        }

        private void sellProduct_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private byte[] SavePhoto() //image convertion
        {
            //this is under the namespace system.IO, we need to add the geenrate
            MemoryStream ms = new MemoryStream(); //build in class, convert photo to byte
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        void refresh()
        {
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.ResetText();
            richTextBox1.Clear();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Title = "Select Image";
            img.Filter = "Image File(*.png;*.jpg;*.jpeg)| *.*";

            if (img.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = new Bitmap(img.FileName);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Title = "Select Image";
            img.Filter = "Image File(*.png;*.jpg;*.jpeg)| *.*";

            if (img.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox2.Image = new Bitmap(img.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                //don't miss to pass the mf "cs" that is how you are creating the connection string

                string query = "insert into sellItem values(@Username, @Name, @Price, @description, @Picture00, @picture01, @category)";
                SqlCommand passing = new SqlCommand(query, con);

                //now we are going to tell what are this @id, @name????
                passing.Parameters.AddWithValue("@Username", username);
                passing.Parameters.AddWithValue("@name", textBox2.Text);
                passing.Parameters.AddWithValue("@Price", textBox3.Text);
                passing.Parameters.AddWithValue("@Description", richTextBox1.Text);

                passing.Parameters.AddWithValue("@picture00", SavePhoto());
                passing.Parameters.AddWithValue("@picture01", SavePhoto());
                //convert pic to byte

                passing.Parameters.AddWithValue("@Category", comboBox1.Text);




                con.Open(); //opening the connection
                int a = passing.ExecuteNonQuery(); //execute query
                                                   //sending me a value 0 or 1, if greater than 0 then insertion happend


                if (a > 0)
                {
                    MessageBox.Show("Submitted Successfully");
                    //BindGridView();
                    refresh();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            home a = new home(username);
            a.Show();
        }
    }
}
