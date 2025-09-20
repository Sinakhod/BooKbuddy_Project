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
    public partial class FrmRecovery : Form
    {
        public FrmRecovery()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            if (Validations.isEmpty(txtUsername.Text,txtPassword.Text, txtComPass.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Empty TextBox!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!Validations.isMatch( txtPassword.Text, txtComPass.Text))
            {
                MessageBox.Show("Passwords do not match.", "Password Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validations.isValidUsername(txtUsername.Text))
            {
                MessageBox.Show("Invalid username. Username should contain only contain 9 Digits.", "Username Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            } 

            if (!Validations.IsValidPassword(txtPassword.Text))
            {
                MessageBox.Show("Password must be at least 8 characters, include 1 uppercase, 1 number, and 1 special character.",
                   "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Password reset!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmLogin LoginHome = new FrmLogin();

            UserCredentials.SetCredentials(txtUsername.Text.Trim(),txtPassword.Text.Trim());

            LoginHome.Show();
            this.Hide();

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

        private void FrmRecovery_Load(object sender, EventArgs e)
        {

        }
    }
}
