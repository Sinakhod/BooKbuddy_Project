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
using System.Data;
using System.Data.SqlClient;


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
            string enteredPassword = txtPasswordLogin.Text.Trim();

            // 1. Empty check
            if (Validations.isEmpty(enteredUsername, enteredPassword))
            {
                MessageBox.Show("Please make sure the required fields are filled",
                    "Fill in Empty Spaces!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Username check
            if (!Validations.isValidUsername(enteredUsername))
            {
                MessageBox.Show("Invalid Username. Username must be 9 digits followed by @mywsu.ac.za.",
                    "Username Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Password strength check (optional on login, usually for register only)
            if (!Validations.IsValidPassword(enteredPassword))
            {
                MessageBox.Show("Password must be at least 8 characters, include 1 uppercase, 1 number, and 1 special character(!).",
                    "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Check database
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT PasswordHash FROM Users WHERE Username=@Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", enteredUsername);

                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("No account found with that username.",
                            "Login Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string storedHash = result.ToString();

                    // 5. Verify password
                    if (PasswordHelper.VerifyPassword(enteredPassword, storedHash))
                    {
                        MessageBox.Show("You have logged in successfully!", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FrmAdminHomePage adminHomePage = new FrmAdminHomePage();
                        adminHomePage.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password. Try again.", "Login Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsernameLogin.Clear();
                        txtPasswordLogin.Focus();
                    }
                }
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
