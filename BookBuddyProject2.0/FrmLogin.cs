using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace BookBuddyProject2._0
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUsernameLogin.Text.Trim();
            string enteredPassword = txtPasswordLogin.Text;

            //  Empty check
            if (Validations.isEmpty(txtUsernameLogin.Text,txtPasswordLogin.Text))
            {
                MessageBox.Show("Please make sure the required fields are filled",
                    "Fill in Empty Spaces!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Username check
            if (!Validations.isValidUsername(txtUsernameLogin.Text))
            {
                MessageBox.Show("Invalid Username. Username must be 9 digits followed by @mywsu.ac.za.",
                    "Username Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Password strength check
            if (!Validations.IsValidPassword(txtPasswordLogin.Text))
            {
                MessageBox.Show("Password must be at least 8 characters, include 1 uppercase, 1 number, and 1 special character(!).",
                    "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (enteredUsername == UserCredentials.Username && enteredPassword == UserCredentials.Password)
            {
                MessageBox.Show("You have logged in successfully!","Successful!" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                FrmHomePage home = new FrmHomePage();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("INVALID DETAILS. Click Forgot Password / Click CREATE ACCOUNT " , "Login Error!" , MessageBoxButtons.OK , MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FrmRecovery().Show();
            this.Hide(); 
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPasswordLogin.PasswordChar = '\0';
            }
            else
            {
                txtPasswordLogin.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FrmRegister().Show();
            this.Hide();
        }

        private void txtUsernameLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
