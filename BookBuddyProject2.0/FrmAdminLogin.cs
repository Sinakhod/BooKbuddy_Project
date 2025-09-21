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
    public partial class FrmAdminLogin : Form
    {
        public FrmAdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUsernameAdminLogin.Text.Trim();
            string enteredPassword = txtPasswordAdminLogin.Text;

            //  Empty check
            if (Validations.isEmpty(txtUsernameAdminLogin.Text , txtPasswordAdminLogin.Text))
            {
                MessageBox.Show("Please make sure the required fields are filled",
                    "Fill in Empty Spaces!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Username check
            if (!Validations.isValidUsername(txtUsernameAdminLogin.Text))
            {
                MessageBox.Show("Invalid Username. Username must be 9 digits followed by @mywsu.ac.za.",
                    "Username Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Password strength check
            if (!Validations.IsValidPassword(txtPasswordAdminLogin.Text))
            {
                MessageBox.Show("Password must be at least 8 characters, include 1 uppercase, 1 number, and 1 special character(!).",
                    "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (enteredUsername == UserCredentials.Username && enteredPassword == UserCredentials.Password)
            {
                MessageBox.Show("You have logged in successfully!", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmAdminHomePage adminHomePage = new FrmAdminHomePage();
                adminHomePage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("INVALID DETAILS. Click Forgot Password / Click CREATE ACCOUNT ", "Login Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordAdminLogin.Clear();
                txtUsernameAdminLogin.Clear();
                txtUsernameAdminLogin.Focus();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FrmAdminRecovery().Show();
            this.Hide();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPasswordAdminLogin.PasswordChar = '\0';
            }
            else
            {
                txtPasswordAdminLogin.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FrmAdminRegister().Show();
            this.Hide();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
