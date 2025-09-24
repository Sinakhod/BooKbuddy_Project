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
using System;
using System.Data.SqlClient;

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
            
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {

            if (Validations.isEmpty(txtFullNameReg.Text, txtUsernameReg.Text, txtEmailReg.Text, txtPasswordReg.Text, txtComPassReg.Text))
            {
                MessageBox.Show("All fields are required!", "Empty Feild Error!" ,MessageBoxButtons.RetryCancel , MessageBoxIcon.Error);
                return;
            }

            if (!Validations.isValidUsername(txtUsernameReg.Text))
            {
                MessageBox.Show("Username must only contain letters, numbers, _, @ or !" , "Username Invalid" , MessageBoxButtons.RetryCancel , MessageBoxIcon.Error);
                return;
            }

            if (!Validations.IsValidStudentEmail(txtEmailReg.Text))
            {       
                MessageBox.Show("Email must be in format: 9 digits + @mywsu.ac.za", "Email Invalid" , MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }

            if (!Validations.IsValidPassword(txtPasswordReg.Text))
            {
                MessageBox.Show("Password must have 1 uppercase, 1 number, and 1 special character (!)");
                return;
            }

            if (!Validations.IsMatch(txtPasswordReg.Text, txtComPassReg.Text))
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // Check if username already exists
                string checkUser = "SELECT COUNT(*) FROM Users WHERE Username=@Username";

                using (SqlCommand checkCmd = new SqlCommand(checkUser, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Username", txtUsernameReg.Text.Trim());
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose another one.",
                            "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                using (SqlConnection conn2 = DatabaseHelper.GetConnection())
                {

                   
                    string hashedPassword = PasswordHelper.HashPassword(txtPasswordReg.Text);

                    string query = "INSERT INTO Users (Username, PasswordHash, Email, FullName) " +
                                   "VALUES (@Username, @PasswordHash, @Email, @FullName)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsernameReg.Text);
                        cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                        cmd.Parameters.AddWithValue("@Email", txtEmailReg.Text);
                        cmd.Parameters.AddWithValue("@FullName", txtFullNameReg.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Registration successful!");

                    // Redirect to Login
                    FrmLogin login = new FrmLogin();
                    login.Show();
                    this.Hide();
                }
            }
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtEmailReg_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
