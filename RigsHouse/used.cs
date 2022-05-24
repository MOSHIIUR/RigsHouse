using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RigsHouse
{
    public partial class used : Form
    {
        string username; string id;
        SqlConnection con = new SqlConnection(connectionString.cs());
        public used(string username)
        {
            InitializeComponent();
            this.username = username;
            BindGridView();
        }

        private void used_Load(object sender, EventArgs e)
        {

        }

        void BindGridView()
        {
            try
            {
                string query = "select Id, username from used"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);


                con.Open();
                //to see output as data table
                SqlDataAdapter sda = new SqlDataAdapter(passing);
                DataTable data = new DataTable();
                sda.Fill(data);
                
                gridView.DataSource = data;
                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //no gap in the bok
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void gridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                id = gridView.SelectedRows[0].Cells[0].Value.ToString();

                buyUsed a = new buyUsed(username, id);
                // this.Hide();
                a.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            home a = new home(username);
            a.Show();
        }

        private void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();

        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select Id, username from used where username=@username";
                SqlCommand sda = new SqlCommand(query, con);
                sda.Parameters.AddWithValue("@username", textBox1.Text);

                con.Open();

                SqlDataAdapter sd = new SqlDataAdapter(sda);
                DataTable data = new DataTable();
                sd.Fill(data);

                gridView.DataSource = data;

                DataGridViewImageColumn dgv = new DataGridViewImageColumn();

                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                gridView.RowTemplate.Height = 80;
                con.Close();
                textBox1.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGridView();
        }
    }
}
