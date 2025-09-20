using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Text;

namespace BookBuddyProject2._0
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  Empty check
            if (Validations.isEmpty(txtUsernameReg.Text, txtPasswordReg.Text, txtComPassReg.Text))
            {
                MessageBox.Show("Please make sure the required fields are filled",
                    "Fill in Empty Spaces!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Username check
            if (!Validations.isValidUsername(txtUsernameReg.Text))
            {
                MessageBox.Show("Invalid Username. Username must be 9 digits followed by @mywsu.ac.za.",
                    "Username Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Password strength check
            if (!Validations.IsValidPassword(txtPasswordReg.Text))
            {
                MessageBox.Show("Password must be at least 1 characters, include 1 uppercase, 1 number, and 1 special character(!).",
                    "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Password match check
            if (!Validations.isMatch(txtPasswordReg.Text, txtComPassReg.Text))
            {
                MessageBox.Show("Passwords do not match.",
                    "Password Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Success
            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmLogin login = new FrmLogin();


            UserCredentials.SetCredentials(txtUsernameReg.Text.Trim(), txtPasswordReg.Text.Trim());

            login.Show();
            this.Hide();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPasswordReg.PasswordChar = '\0';
                txtComPassReg.PasswordChar = '\0';
            }
            else
            {
                txtPasswordReg.PasswordChar = '•';
                txtComPassReg.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear_Click(sender, e);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            txtUsernameReg.Clear();
            txtPasswordReg.Clear();
            txtComPassReg.Clear();
        }
    }
}
