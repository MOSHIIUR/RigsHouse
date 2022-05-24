using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RigsHouse
{
    public partial class buyUsed : Form
    {
        string username;    user a = new user(); Cuproduct p = new Cuproduct(); Cproduct c = new Cproduct();
        public buyUsed(string username, string id)
        {
            InitializeComponent();
            this.username = username;
            a.getInfo(username);    p.UgetInfo(id); 
            p.getCartStatus();
            
            
            pictureBox1.Image = p.pic00;
            pictureBox2.Image = p.pic01;

            productName.Text = p.name;

            label7.Text = p.Username;
            label8.Text = p.price + "৳";
            richTextBox1.Text = p.description;

            if(p.status == "0")
            {

                label3.Visible = true;

            }

            else if(username == p.Username) { label3.Visible = false; }



            else
            {

                button1.Visible = true; 
            }





        }

        private void buyUsed_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          bool flag = p.buyItem(username, p.Username, Convert.ToInt32(1));

            if (flag)
            {
                MessageBox.Show("Purchase Successfull.", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                p.updateUsedProductList();
                p.addSellerAccount(p.Username, p.price);

                this.Hide();
                printPreviewDialog1.Document = printDocument1;
                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("RigsHouse", 200, 200);
                printPreviewDialog1.ShowDialog();

            }

            else
            {
                MessageBox.Show("Unsuccessful", "Please Try again");
            }

    


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {



        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("RigsHouse", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(50, 0));

            e.Graphics.DrawString("Buyer Name: " + a.name, new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(0, 40));//name

            e.Graphics.DrawString("Product Name: " + p.name, new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(0, 50));

            e.Graphics.DrawString("Number of Unit: " + 1, new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(0, 70));
            e.Graphics.DrawString("Unit Price: " + p.price, new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(0, 80));
            e.Graphics.DrawString("Total Price: " + p.price, new Font("Arial", 6, FontStyle.Bold), Brushes.Black, new Point(0, 90));

            e.Graphics.DrawString("Invoice Print Time: " + DateTime.Now.ToString(), new Font("Arial", 6, FontStyle.Regular), Brushes.Black, new Point(0, 110));

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
        }
    }
}
