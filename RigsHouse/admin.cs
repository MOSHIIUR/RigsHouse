using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RigsHouse
{
    public partial class admin : Form
    {
        string username;
        public admin(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageUser a = new manageUser(username);
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageProduct a = new manageProduct(username);
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            purchaseList a = new purchaseList(username);
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageSell a = new manageSell(username);
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            account a = new account(username);
            a.Show();
        }
    }
}
