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
    public partial class manageUser : Form
    {
        SqlConnection con = new SqlConnection(connectionString.cs());

        string userName;

        public manageUser(string username)
        {
            this.userName = username;
            InitializeComponent(); 
            BindGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            addUser a = new addUser(userName);
            a.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin a = new admin(userName);
            a.Show();
        }

        private void manageUser_Load(object sender, EventArgs e)
        {

        }


        void BindGridView()
        {
            try
            {
                string query = "select Name, Username, picture from User_info";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                con.Open();

                DataTable data = new DataTable();
                sda.Fill(data);

                gridView.DataSource = data;

                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)gridView.Columns[2];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                gridView.RowTemplate.Height = 80;
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
                string username = gridView.SelectedRows[0].Cells[1].Value.ToString();
                this.Hide();
                userInfo a = new userInfo(username);
                a.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select Name, Username, picture from User_info where username=@username";
                SqlCommand sda = new SqlCommand(query, con);
                sda.Parameters.AddWithValue("@username", textBox1.Text);

                con.Open();

                SqlDataAdapter sd = new SqlDataAdapter(sda);
                DataTable data = new DataTable();
                sd.Fill(data);

                gridView.DataSource = data;

                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)gridView.Columns[2];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

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

        private void textBox1_TextChanged(object sender, EventArgs e)
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
