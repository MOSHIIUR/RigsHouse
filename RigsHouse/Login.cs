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

namespace RigsHouse
{
    public partial class Login : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["pltops"].ConnectionString;
        string status;
        public Login()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;

            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("Select * from User_Info where UserName = @UserName and Password= @Password", con);
                cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);


                con.Open();


                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                cmd.ExecuteNonQuery();

                if (dt.Rows.Count.Equals(1))
                {
                    status = dt.Rows[0][3].ToString().Trim();
                    if (status == "0")
                    {
                        admin wr = new admin(textBox1.Text);
                        this.Hide();
                        wr.Show();
                    }


                    else if (status == "2")
                    {
                        home rc = new home(textBox1.Text);
                        this.Hide();
                        rc.Show();

                    }


                }

                else
                {
                    MessageBox.Show("Wrong UserName & Password");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void checkBox1_Leave(object sender, EventArgs e)
        {
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resource1.error;
                errorProvider1.SetError(this.textBox1, "Fill the field");
            }
            else
            {
                errorProvider1.Icon = Properties.Resource1.check;
                errorProvider1.SetError(this.textBox1, "Field is succesfully filled");

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resource1.error;
                errorProvider2.SetError(this.textBox2, "Fill the field");
            }
            else
            {
                errorProvider2.Icon = Properties.Resource1.check;
                errorProvider2.SetError(this.textBox2, "Field is succesfully filled");

            }


        }

        private void label5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            createAccount a = new createAccount();
            a.Show();
        }
    }
}
