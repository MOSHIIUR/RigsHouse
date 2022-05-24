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



namespace RigsHouse
{
    public partial class productDescription : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["pltops"].ConnectionString;
        string Username, category;    Cproduct p = new Cproduct();


     
        
        public productDescription(string username, string id)
        {
            InitializeComponent();
            this.Username = username;
            p.getInfo(id); p.getCartStatus();

            pictureBox1.Image = p.pic;
            label2.Text = p.name;
            label3.Text = "@"+p.id;
            label7.Text = Convert.ToString(p.Sprice)+"৳";
            label8.Text = Convert.ToString(p.Rprice)+"৳";
            richTextBox1.Text = p.description;
            
            if(p.cartStatus!="1")
            {
                button2.Visible = true;
                numericUpDown2.Visible = true;
            }
            btnBack.Visible = false;
            
        }

        public productDescription(string username, string id, string category)
        {
            InitializeComponent();
            this.Username = username; this.category = category;
            p.getInfo(id); p.getCartStatus();

            pictureBox1.Image = p.pic;
            label2.Text = p.name;
            label3.Text = "@"+p.id;
            label7.Text = Convert.ToString(p.Sprice)+"৳";
            label8.Text = Convert.ToString(p.Rprice)+"৳";
            richTextBox1.Text = p.description;
            
            if(p.cartStatus!="1")
            {
                button2.Visible = true;
                numericUpDown2.Visible = true;
            }
            
        }

        private void productDescription_Load(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            int a = p.cart(Username, Convert.ToInt32(numericUpDown2.Value));
            
            if (a > 0)
            {
                MessageBox.Show("Added to the cart");
                numericUpDown2.Visible = false;
                button2.Visible = false;
            }
            else
            {
                MessageBox.Show("Unable to Add");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value>0)
            {
                mBuy a = new mBuy(Username, p.id, Convert.ToInt32(numericUpDown1.Value));
                a.Show();

            }

            else
            {
                MessageBox.Show("Product unit Empty!!!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(55, 73, 187);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            displayProduct a = new displayProduct(Username, category, 0);
            this.Hide();
            a.Show();
        }
    }
}
