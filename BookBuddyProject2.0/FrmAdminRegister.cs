using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookBuddyProject2._0
{
    public partial class FrmAdminRegister : Form
    {
        public FrmAdminRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtComPass.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text != txtComPass.Text)
            {
                MessageBox.Show("Password does not match, Please re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtComPass.Text = "";
                txtPassword.Focus();
            }
            else if (!txtUsername.Text.EndsWith("@mywsu.ac.za"))
            {
                MessageBox.Show("Invalid Username or Password, Please try again", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
            else
            {
                MessageBox.Show("Your have Registered", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new FrmAdminHomePage().Show();
                this.Hide();
            }
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPass.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComPass.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FrmAdminLogin().Show();
            this.Hide(); 
        }
    }
}
