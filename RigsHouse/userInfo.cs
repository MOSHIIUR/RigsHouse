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
    public partial class userInfo : Form

    {
        string username; 
        user a = new user();   



        public userInfo(string Username)
        {
            InitializeComponent();
            this.username = Username;
            a.getInfo(username); a.usages();



            // getUsages(Username);
            label8.Text = "@"+a.username;
            productName.Text = a.name;
            label7.Text = a.address;
            label2.Text = a.mail;

            if (a.status == 0)
            {
                label3.Text = "Admin";
                
            }

            else if (a.status == 1)
                label3.Text = "Expert";
            
            else
            {
                label3.Text = "User";

                label5.Visible = true;
                label6.Visible = true;
                buy.Visible = true;
                sell.Visible = true;

                buy.Text = a.Tsum + "৳";
                sell.Text = a.Ssum + "৳";

            }



            pictureBox1.Image = a.pic;
        }

        private void adress_Click(object sender, EventArgs e)
        {

        }

        private void userInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int b = a.deleteUser();

            if (b > 0)
            {
                MessageBox.Show("User Deleted Successfully");
                this.Hide();
                manageUser a = new manageUser(username);
                a.Show();
            }
            else
            {
                MessageBox.Show("User Not Deleted");
            }


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageUser a = new manageUser(username);
            a.Show();
        }
    }
}
