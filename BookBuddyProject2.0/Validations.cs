using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuddyProject2._0
{
    internal class Validations
    {
        public static bool isEmpty(params string[] fields)
        {
            foreach (string field in fields)
            {
                if (string.IsNullOrWhiteSpace(field))
                    return true;  // Found an empty field
            }
            return false; // All fields are filled
        }
        public static bool isMatch (string txtPassword, string txtComPass)             // Method to check if the password and confirm password fields match
        {
            if (txtPassword != txtComPass)
            {
                return false;
            }
            return true;
        }

        public static bool isValidUsername(string txtUsername)                   // Method to check if the username is valid 

        {
            // Check if it ends with "@mywsu.ac.za"
            string domain = "@mywsu.ac.za";
            if (!txtUsername.EndsWith(domain))
                return false;

            // Extract the part before the domain
            string studentNumber = txtUsername.Substring(0, txtUsername.Length - domain.Length);

            // Check if it is exactly 9 characters and all digits
            if (studentNumber.Length != 9 || !studentNumber.All(char.IsDigit))
                return false;

            return true;
        }

        public static bool IsValidPassword(params string[] passwords)
        {
            foreach (string password in passwords)
            {
                // Check length
                if (password.Length < 8)
                    return false;

                bool hasUpper = false;
                bool hasNumber = false;
                bool hasSpecial = false;

                foreach (char c in password)
                {
                    if (char.IsUpper(c))
                        hasUpper = true;
                    else if (char.IsDigit(c))
                        hasNumber = true;
                    else if (!char.IsLetterOrDigit(c))
                        hasSpecial = true;
                }

                if (!(hasUpper && hasNumber && hasSpecial))
                    return false;
            }

            return true;
        }




    }
}
