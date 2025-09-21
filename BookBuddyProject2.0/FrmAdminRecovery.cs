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
            if (Validations.isEmpty(txtUsernameRecoAdmin.Text,txtComPassRecoAdmin.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Empty TextBox!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validations.isMatch(txtPasswordRecoAdmin.Text,txtComPassRecoAdmin.Text))
            {
                MessageBox.Show("Passwords do not match.", "Password Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validations.isValidUsername(txtUsernameRecoAdmin.Text))
            {
                MessageBox.Show("Invalid username. Username should contain only contain 9 Digits.", "Username Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!Validations.IsValidPassword(txtPasswordRecoAdmin.Text))
            {
                MessageBox.Show("Password must be at least 8 characters, include 1 uppercase, 1 number, and 1 special character.",
                   "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Password reset!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmAdminLogin LoginAdminHome = new FrmAdminLogin();

            UserCredentials.SetCredentials(txtUsernameRecoAdmin.Text,txtPasswordRecoAdmin.Text);

            LoginAdminHome.Show();
            this.Hide();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPasswordRecoAdmin.PasswordChar = '\0';
                txtComPassRecoAdmin.PasswordChar = '\0';
            }
            else
            {
                txtPasswordRecoAdmin.PasswordChar = '•';
                txtComPassRecoAdmin.PasswordChar = '•';
            }
        }
    }
}
