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
    public partial class updateAccount : Form
    {
        user a = new user();
        string username;

        public updateAccount(string username)
        {
            InitializeComponent();
            this.username = username;
            a.getInfo(username);

            txtName.Text = a.name;
            txtEmail.Text = a.mail;
            comboBox1.Text = a.gender;
            textAddress.Text = a.address;
            pictureBox1.Image = a.pic;

        }

        private void updateAccount_Load(object sender, EventArgs e)
        {

        }




        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            account a = new account(username);
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int b = a.updateAcc(txtName.Text, comboBox1.Text, txtEmail.Text, textAddress.Text, pictureBox1.Image);

            if (b > 0)
            {
                MessageBox.Show("Data Update Successfully");
                this.Hide();
                account c = new account(username);
                c.Show();
            }
            else
            {
                MessageBox.Show("Data Not Updated");
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Title = "Select Image";
            img.Filter = "Image File(*.png;*.jpg;*.jpeg)| *.*";

            if (img.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = new Bitmap(img.FileName);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();

        }
    }
}
