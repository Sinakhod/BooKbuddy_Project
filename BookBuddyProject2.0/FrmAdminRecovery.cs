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
    public partial class FrmAdminRecovery : Form
    {
        public FrmAdminRecovery()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string newPass = txtPassword.Text;
            string confirmPass = txtComPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserCredentials.Username = txtUsername.Text.Trim();
            UserCredentials.Password = txtPassword.Text;


            if (txtUsername.Text.EndsWith("@mywsu.ac.za"))
            {
                MessageBox.Show("Password successfully reset!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new FrmAdminLogin().Show();
            }
            else
            {
                MessageBox.Show("Username incorrect.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
