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
    public partial class account : Form
    {
        user a = new user();


        string username;

        public account()
        {
            InitializeComponent();
        }

        public account(string username)
        {
            InitializeComponent();
            this.username = username;
            // getInfo(username);
            a.getInfo(username);
            label1.Text = a.name;
            label4.Text = a.mail;
            label3.Text = a.address;
            pictureBox1.Image = a.pic;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            home a = new home(username);
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            sellProduct a = new sellProduct(username);
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

        }

        private void account_Load(object sender, EventArgs e)
        {

        }





        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            updateAccount a = new updateAccount(username);
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            passChange a = new passChange(username);
            a.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
                    
            if(a.status == 2)
            {
                this.Hide();
                home c = new home(username);
                c.Show();
            }

            else 
            {
                this.Hide();
                admin c = new admin(username);
                c.Show();
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();
        }
    }
}
