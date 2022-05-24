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
    public partial class manageProduct : Form
    {
       string cs = ConfigurationManager.ConnectionStrings["pltops"].ConnectionString;
        string username;
        public manageProduct(string username)
        {
            InitializeComponent();
            BindGridView();
            this.username = username;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.Title = "Select Image";
            img.Filter = "Image File(*.png;*.jpg;*.jpeg)| *.*";

            if (img.ShowDialog() == DialogResult.OK)
            {
                this.img.Image = new Bitmap(img.FileName);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection(cs);
                //don't miss to pass the mf "cs" that is how you are creating the connection string

                string query = "insert into product values(@id, @name, @Rprice, @discount, @category, @unit, @picture, @description)";
                SqlCommand passing = new SqlCommand(query, con);

                //now we are going to tell what are this @id, @name????
                passing.Parameters.AddWithValue("@id", textBox1.Text);
                passing.Parameters.AddWithValue("@name", textBox2.Text);
                passing.Parameters.AddWithValue("@Rprice", textBox3.Text);
                passing.Parameters.AddWithValue("@discount", textBox4.Text);
                passing.Parameters.AddWithValue("@category", comboBox1.Text);
                passing.Parameters.AddWithValue("@unit", numericUpDown1.Value);
                passing.Parameters.AddWithValue("@description", richTextBox1.Text);

                passing.Parameters.AddWithValue("@picture", SavePhoto());
                //convert pic to byte



                con.Open(); //opening the connection
                int a = passing.ExecuteNonQuery(); //execute query
                                                   //sending me a value 0 or 1, if greater than 0 then insertion happend


                if (a > 0)
                {
                    MessageBox.Show("Data Inserted Successfully");
                    BindGridView();
                    refresh();
                }
                else
                {
                    MessageBox.Show("Data Not Inserted");
                }

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private byte[] SavePhoto() //image convertion
        {
            //this is under the namespace system.IO, we need to add the geenrate
            MemoryStream ms = new MemoryStream(); //build in class, convert photo to byte
            img.Image.Save(ms, img.Image.RawFormat);
            return ms.GetBuffer();
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
                viewData.DataSource = data;

                //to see the image properly
                DataGridViewImageColumn dgv = new DataGridViewImageColumn();

                dgv = (DataGridViewImageColumn)viewData.Columns[6]; //saying him which one is the img column

                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch; //fit the image

                viewData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //no gap in the bok

                viewData.RowTemplate.Height = 80;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refresh()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.ResetText();
            numericUpDown1.Value = 0;
            img.Image = null;
            richTextBox1.Clear();

        }

        private void product_insert_Load(object sender, EventArgs e)
        {

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
                textBox1.Text = viewData.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = viewData.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = viewData.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = viewData.SelectedRows[0].Cells[3].Value.ToString();
                comboBox1.Text = viewData.SelectedRows[0].Cells[4].Value.ToString();
                numericUpDown1.Value = Convert.ToInt32(viewData.SelectedRows[0].Cells[5].Value);
                img.Image = GetPhoto((byte[])viewData.SelectedRows[0].Cells[6].Value);
                richTextBox1.Text = viewData.SelectedRows[0].Cells[7].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                //don't miss to pass the mf "cs" that is how you are creating the connection string

                string query = "update product set name=@name, Rprice=@Rprice, discount=@discount, category=@category, unit=@unit, picture=@picture, description=@description where id=@id";
                SqlCommand passing = new SqlCommand(query, con);

                //now we are going to tell what are this @id, @name????
                passing.Parameters.AddWithValue("@id", textBox1.Text);
                passing.Parameters.AddWithValue("@name", textBox2.Text);
                passing.Parameters.AddWithValue("@Rprice", textBox3.Text);
                passing.Parameters.AddWithValue("@discount", textBox4.Text);
                passing.Parameters.AddWithValue("@category", comboBox1.Text);
                passing.Parameters.AddWithValue("@unit", numericUpDown1.Value);
                passing.Parameters.AddWithValue("@description", richTextBox1.Text);

                passing.Parameters.AddWithValue("@picture", SavePhoto());
                //convert pic to byte



                con.Open(); //opening the connection
                int a = passing.ExecuteNonQuery(); //execute query
                                                   //sending me a value 0 or 1, if greater than 0 then insertion happend


                if (a > 0)
                {
                    MessageBox.Show("Data Update Successfully");
                    refresh();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                //don't miss to pass the mf "cs" that is how you are creating the connection string

                string query = "delete from product where id=@id";
                SqlCommand passing = new SqlCommand(query, con);

                //now we are going to tell what are this @id, @name????
                passing.Parameters.AddWithValue("@id", textBox1.Text);



                con.Open(); //opening the connection
                int a = passing.ExecuteNonQuery(); //execute query
                                                   //sending me a value 0 or 1, if greater than 0 then insertion happend


                if (a > 0)
                {
                    MessageBox.Show("Data Deleted Successfully");
                    BindGridView();
                    refresh();
                }
                else
                {
                    MessageBox.Show("Data Not Deleted");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
            BindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            a.Show();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {

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

                viewData.DataSource = data;

                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)viewData.Columns[2];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

                viewData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                viewData.RowTemplate.Height = 80;
                comboBox1.ResetText();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
