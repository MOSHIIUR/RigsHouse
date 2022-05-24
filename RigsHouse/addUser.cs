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
    public partial class addUser : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["pltops"].ConnectionString;
        string username;

        public addUser(string username)
        {
            InitializeComponent();  this.username = username;
        }

        private void addUser_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageUser a = new manageUser(username);
                a.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                //don't miss to pass the mf "cs" that is how you are creating the connection string

                string query = "insert into User_Info values(@name, @Gender, @Mail, @Status, @Address, @picture, @Username, @password)";
                SqlCommand passing = new SqlCommand(query, con);

                //now we are going to tell what are this @id, @name????
                passing.Parameters.AddWithValue("@name", txtName.Text);
                passing.Parameters.AddWithValue("@Gender", comboBox1.Text);
                passing.Parameters.AddWithValue("@Mail", txtEmail.Text);
                if (comboBox2.Text == "Admin")
                    passing.Parameters.AddWithValue("@Status", 0);
                else passing.Parameters.AddWithValue("@Status", 1);
                passing.Parameters.AddWithValue("@Address", textAddress.Text);
                passing.Parameters.AddWithValue("@Username", txtUserName.Text);
                passing.Parameters.AddWithValue("@password", txtPass.Text);

                passing.Parameters.AddWithValue("@picture", SavePhoto());
                //convert pic to byte



                con.Open(); //opening the connection
                int a = passing.ExecuteNonQuery(); //execute query
                                                   //sending me a value 0 or 1, if greater than 0 then insertion happend


                if (a > 0)
                {
                    MessageBox.Show("Data Inserted Successfully");
                    refresh();
                }
                else
                {
                    MessageBox.Show("Data Not Inserted");
                }

                con.Close();

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
            img.Image.Save(ms, img.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Title = "Select Image";
            img.Filter = "Image File(*.png;*.jpg;*.jpeg)| *.*";

            if (img.ShowDialog() == DialogResult.OK)
            {
                this.img.Image = new Bitmap(img.FileName);
            }

        }

        void refresh()
        {
            txtName.Clear();
            txtEmail.Clear();
            textAddress.Clear();
            comboBox1.ResetText();
            txtUserName.Clear();
            txtPass.Clear();

            img.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();
        }
    }
}
