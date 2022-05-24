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
    public partial class cart : Form
    {
        SqlConnection con = new SqlConnection(connectionString.cs()); 
        string username; Cproduct p = new Cproduct();
        public cart(string username)
        {
            InitializeComponent();
            this.username = username;
            BindGridView();
        }

        void BindGridView()
        {
            try
            {
                string query = "select Id, Name, unit from cart where Username=('" + username + "')"; //we want to see

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


        private void cart_Load(object sender, EventArgs e)
        {

        }

        private void cart_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void viewData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id = viewData.SelectedRows[0].Cells[0].Value.ToString();
            string unit = (viewData.SelectedRows[0].Cells[2].Value.ToString());
           
            Cbuy a = new Cbuy(username, id, unit);
            a.Show();
           // BindGridView();
            


        }

        private void viewData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = (viewData.SelectedRows[0].Cells[0].Value.ToString());
            numericUpDown1.Value = int.Parse(viewData.SelectedRows[0].Cells[2].Value.ToString());

        }

        private void refresh()
        {
            textBox1.Clear();
            numericUpDown1.Value = 0;

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown1.Value!=0)
                {
                    //don't miss to pass the mf "cs" that is how you are creating the connection string

                    string query = "update cart set unit=@unit where id=@id";
                    SqlCommand passing = new SqlCommand(query, con);

                    //now we are going to tell what are this @id, @name????
                    passing.Parameters.AddWithValue("@id", textBox1.Text);
                    passing.Parameters.AddWithValue("@unit", numericUpDown1.Value);



                    con.Open(); //opening the connection
                    int a = passing.ExecuteNonQuery(); //execute query
                                                       //sending me a value 0 or 1, if greater than 0 then insertion happend


                    if (a > 0)
                    {
                        MessageBox.Show("Data Update Successfully");
                        BindGridView();
                        refresh();
                    }
                    else
                    {
                        MessageBox.Show("Data Not Updated");
                    }

                    con.Close();

                }

                else MessageBox.Show("At least one unit of product needs to be selected");
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
                string query = "delete from cart where id=@id";
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
    }
}
