using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RigsHouse
{
    public partial class passChange : Form
    {   user a = new user();    string username;
        public passChange(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Hide();
            account a = new account(username);
            a.Show();

        }

        private void passChange_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           a.getInfo(username);
          a.changePass(txtOldPass.Text, txtNewPass.Text, txtConfirmPass.Text);
            
        }


    }
}
