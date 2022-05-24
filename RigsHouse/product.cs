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
    public partial class product : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["pltops"].ConnectionString;
        string id, name, Username, description; int Rprice, sprice;
        byte[] img;

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            home a = new home(Username);
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from product where category=@category";
                SqlCommand passing = new SqlCommand(query, con);

                passing.Parameters.AddWithValue("@category", comboBox1.Text);


                SqlDataAdapter sd = new SqlDataAdapter(passing);
                DataTable data = new DataTable();
                sd.Fill(data);
                gridView.DataSource = data;

                //to see the image properly
                DataGridViewImageColumn dgv = new DataGridViewImageColumn();

                dgv = (DataGridViewImageColumn)gridView.Columns[6]; //saying him which one is the img column

                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch; //fit the image

                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //no gap in the bok

                gridView.RowTemplate.Height = 80;
                comboBox1.ResetText();

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

        public product(String Username)
        {
            InitializeComponent();
            BindGridView();
            this.Username = Username;
        }

        private void product_Load(object sender, EventArgs e)
        {

        }

        void BindGridView()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from product"; //we want to see
                SqlCommand passing = new SqlCommand(query, con);
                //to see output as data table
                DataTable data = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(passing);
                sda.Fill(data);
                gridView.DataSource = data;

                //to see the image properly
                DataGridViewImageColumn dgv = new DataGridViewImageColumn();

                dgv = (DataGridViewImageColumn)gridView.Columns[6]; //saying him which one is the img column

                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch; //fit the image

                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //no gap in the bok

                gridView.RowTemplate.Height = 80;
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

                productDescription a = new productDescription(Username, id);
                // this.Hide();
                a.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
