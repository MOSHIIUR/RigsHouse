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
using System.Data;

namespace RigsHouse
{
    public partial class purchaseList : Form
    {
        SqlConnection con = new SqlConnection(connectionString.cs());
        string username;
        public purchaseList(string username)
        {
            InitializeComponent();
            this.username = username;
            BindGridView();
        }

        void BindGridView()
        {
            try
            {
                string query = "select id, name, unit, price, serial from buy where id is not NULL"; //we want to see

                SqlDataAdapter sda = new SqlDataAdapter(query, con);

                //to see output as data table
                DataTable data = new DataTable();
                sda.Fill(data);
                viewData.DataSource = data;

                viewData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //no gap in the bok

                viewData.RowTemplate.Height = 80;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void manageRigs_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin a = new admin(username);
            a.Show();

        }

        private void viewData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                string id = viewData.SelectedRows[0].Cells[0].Value.ToString();
                string unit = (viewData.SelectedRows[0].Cells[2].Value.ToString());
                string price = (viewData.SelectedRows[0].Cells[3].Value.ToString());
                string serial = (viewData.SelectedRows[0].Cells[4].Value.ToString());
                purchaseInfo a = new purchaseInfo(username, id, unit, price, serial);
                a.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT sum(price) FROM buy";

            SqlCommand passing = new SqlCommand(query, con);
           




            con.Open(); 

            SqlDataAdapter sd = new SqlDataAdapter(passing);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            passing.ExecuteNonQuery();

            string sum = dt.Rows[0][0].ToString();


            MessageBox.Show("Total Selling amount: " + sum);
            con.Close();

        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select id, name, unit, price, serial from buy where Username=@Username and ID is not NULL"; //we want to see
                SqlCommand sda = new SqlCommand(query, con);
                sda.Parameters.AddWithValue("@Username", textBox1.Text);

                con.Open();

                SqlDataAdapter sd = new SqlDataAdapter(sda);
                DataTable data = new DataTable();
                sd.Fill(data);

                viewData.DataSource = data;

                viewData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                viewData.RowTemplate.Height = 60;
                con.Close();
                
                textBox1.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
