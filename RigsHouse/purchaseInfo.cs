using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RigsHouse
{
    public partial class purchaseInfo : Form
    {
        SqlConnection con = new SqlConnection(connectionString.cs());
        string username, serial; Cproduct p = new Cproduct(); 
        public purchaseInfo(string username, string id, string unit, string price, string serial)
        {
            InitializeComponent();
            this.username = username; this.serial = serial;
            p.getInfo(id); p.findBuyer();
            productName.Text = p.name;
            label7.Text = p.buyerName;
            label8.Text = unit;
            label9.Text = Convert.ToString(p.Rprice)+ "৳";
            label10.Text = price+ "৳";
            pictureBox1.Image = p.pic;
        }

        private void purchaseInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                string query = "delete from buy where serial=@serial";
                SqlCommand passing = new SqlCommand(query, con);

                //now we are going to tell what are this @id, @name????
                passing.Parameters.AddWithValue("@serial", serial);



                con.Open(); //opening the connection
                int a = passing.ExecuteNonQuery(); //execute query
                                                   //sending me a value 0 or 1, if greater than 0 then insertion happend
                if (a > 0)
                {
                    MessageBox.Show("Transection Deleted Successfully");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Data Not Updated");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
