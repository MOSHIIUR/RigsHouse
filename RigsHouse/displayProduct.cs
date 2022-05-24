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
    public partial class displayProduct : Form
    {
        string username, category; int number; Cproduct p = new Cproduct();
        string id1, id2, id3, id4, id5, id6;
        public displayProduct(string username, string category, int num)
        {
            InitializeComponent();
            this.username = username;
            this.category = category; label1.Text = category;
            number = num;
            int row = p.getColumn(category);

            if (number == 0)
            {
                privious.Visible = false;
            }

            if (number < row)
            {

                pictureBox1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                button1.Visible = true;

                p.find(number, category);
                id1 = p.id;
                pictureBox1.Image = p.pic;
                label2.Text = p.name;
                label3.Text = p.Sprice + "৳";
                this.number++;
            }

            if (number < row)
            {

                pictureBox2.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                button2.Visible = true;

                p.find(number, category); id2 = p.id;
                pictureBox2.Image = p.pic;
                label4.Text = p.name;
                label5.Text = p.Sprice + "৳";
                number++;
            }

            if (number < row)
            {

                pictureBox3.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                button3.Visible = true;

                p.find(number, category); id3 = p.id;
                pictureBox3.Image = p.pic;
                label6.Text = p.name;
                label7.Text = p.Sprice + "৳";
                number++;
            }

            if (number < row)
            {

                pictureBox4.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                button4.Visible = true;

                p.find(number, category); id4 = p.id;
                pictureBox4.Image = p.pic;
                label8.Text = p.name;
                label9.Text = p.Sprice + "৳";
                number++;
            }

            if (number < row)
            {

                pictureBox5.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                button5.Visible = true;

                p.find(number, category); id5 = p.id;
                pictureBox5.Image = p.pic;
                label10.Text = p.name;
                label11.Text = p.Sprice + "৳";
                number++;
            }

            if (number < row)
            {

                pictureBox6.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                button6.Visible = true;

                p.find(number, category); id6 = p.id;
                pictureBox6.Image = p.pic;
                label12.Text = p.name;
                label13.Text = p.Sprice + "৳";
                number++;
            }

            if (number > 5 && number<row)
            {
                next.Visible = true;
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide(); productDescription a = new productDescription(username, id2, category);
            a.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide(); productDescription a = new productDescription(username, id3, category);
            a.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide(); productDescription a = new productDescription(username, id4, category);
            a.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide(); productDescription a = new productDescription(username, id5, category);
            a.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide(); productDescription a = new productDescription(username, id6, category);
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            home a = new home(username);
            a.Show();

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Orange;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void displayProduct_Load(object sender, EventArgs e)
        {

        }

        private void privious_Click(object sender, EventArgs e)
        {
            displayProduct a = new displayProduct(username, category, 0);
            this.Hide();
            a.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide(); productDescription a = new productDescription(username, id1, category);
            a.Show();
        }

        private void next_Click(object sender, EventArgs e)
        {
            displayProduct a = new displayProduct(username, category, number);
            this.Hide();
            a.Show();
        }
    }
}
