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
            string enteredUsername = txtUsername.Text.Trim();
            string enteredPassword = txtpassword.Text;

            if (enteredUsername == "" || enteredPassword == "")
            {
                MessageBox.Show("Please enter both your username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }


            if (!enteredUsername.EndsWith("@mywsu.ac.za"))
            {
                MessageBox.Show("Please use a valid WSU email address (e.g. user@mywsu.ac.za).", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Clear();
                txtpassword.Clear();
                txtUsername.Focus();
                return;
            }


            if (enteredUsername != UserCredentials.Username && enteredPassword != UserCredentials.Password)
            {
                Login.SetUser(enteredUsername, enteredPassword);

                MessageBox.Show("Please use a valid WSU email address (e.g. user@mywsu.ac.za).", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Clear();
                txtpassword.Clear();
                txtUsername.Focus();
                return;
            }

            MessageBox.Show("You have logged in successfully!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            new FrmAdminHomePage().Show();
            this.Hide();
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
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '•';
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
