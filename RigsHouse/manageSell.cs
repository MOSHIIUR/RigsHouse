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
    public partial class manageSell : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["pltops"].ConnectionString;
        string username;

        public manageSell(string username)
        {
            InitializeComponent(); this.username = username;
            BindGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin a = new admin(username);
            a.Show();

        }

        private void manageSell_Load(object sender, EventArgs e)
        {

        }

        void BindGridView()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select username, serial from sellItem"; //we want to see

                SqlDataAdapter sda = new SqlDataAdapter(query, con);

                //to see output as data table
                DataTable data = new DataTable();
                sda.Fill(data);
                gridView.DataSource = data;


                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //no gap in the bok

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
                string serial = gridView.SelectedRows[0].Cells[1].Value.ToString();

                this.Hide();
                sellResponse a = new sellResponse(username, serial);
                a.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            sellProduct a = new sellProduct("pltop");
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            used a = new used("pltop");
            a.Show();
        }
    }
}
