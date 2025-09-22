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
            //  Empty check
            if (Validations.isEmpty(txtUsernameAdminReg.Text,txtPasswordAdminReg.Text,txtComPassAdminReg.Text))
            {
                MessageBox.Show("Please make sure the required fields are filled",
                    "Fill in Empty Spaces!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                
                return;
            }

            //  Username check
            if (!Validations.isValidUsername(txtUsernameAdminReg.Text))
            {
                MessageBox.Show("Invalid Username. Username must be 9 digits followed by @mywsu.ac.za.",
                    "Username Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Password strength check
            if (!Validations.IsValidPassword(txtPasswordAdminReg.Text))
            {
                MessageBox.Show("Password must be at least 1 characters, include 1 uppercase, 1 number, and 1 special character(!).",
                    "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Password match check
            if (!Validations.IsMatch(txtPasswordAdminReg.Text,txtComPassAdminReg.Text))
            {
                MessageBox.Show("Passwords do not match.",
                    "Password Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  Success
            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

          FrmAdminLogin loginAdmin = new FrmAdminLogin();


            UserCredentials.SetCredentials(txtUsernameAdminReg.Text.Trim(),txtPasswordAdminReg.Text.Trim());

            loginAdmin.Show();
            this.Hide();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPasswordAdminReg.PasswordChar = '\0';
                txtComPassAdminReg.PasswordChar = '\0';
            }
            else
            {
                txtPasswordAdminReg.PasswordChar = '•';
                txtComPassAdminReg.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FrmAdminLogin().Show();
            this.Hide(); 
        }

        private void btnClearReg_Click(object sender, EventArgs e)
        {
            txtUsernameAdminReg.Clear();
            txtPasswordAdminReg.Clear();
            txtComPassAdminReg.Clear();
        }

        private void FrmAdminRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
