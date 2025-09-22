using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

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
            string username = txtUsername.Text.Trim();
            string newPassword = txtPassword.Text;

            // 1. Empty check
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Validate password strength
            if (!Validations.IsValidPassword(newPassword))
            {
                MessageBox.Show("Password must be at least 8 characters, include 1 uppercase, 1 number, and 1 special character(!).",
                    "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 3. Check if username exists
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        int userExists = (int)checkCmd.ExecuteScalar();

                        if (userExists == 0)
                        {
                            MessageBox.Show("No account found with that username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 4. Hash the new password
                    string hashedPassword = PasswordHelper.HashPassword(newPassword);

                    // 5. Update password in database
                    string updateQuery = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Username = @Username";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                        updateCmd.Parameters.AddWithValue("@Username", username);

                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Close recovery form after success
                        }
                        else
                        {
                            MessageBox.Show("Failed to update password. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmRecovery_Load(object sender, EventArgs e)
        {

        }
    }
}
