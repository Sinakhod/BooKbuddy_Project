using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        public static bool isValidUsername(string Username)                   // Method to check if the username is valid 

        {
            if (string.IsNullOrWhiteSpace(Username))
                return false;

            foreach (char c in Username)
            {
                if (!(char.IsLetterOrDigit(c) || c == '_' || c == '@' || c == '!'))
                    return false;
            }

            return true;
        }
        public static bool IsValidStudentEmail(string email)
        {
            string domain = "@mywsu.ac.za";
            if (!email.EndsWith(domain))
                return false;

            string studentNumber = email.Substring(0, email.Length - domain.Length);

            if (studentNumber.Length != 9 || !studentNumber.All(char.IsDigit))
                return false;

            return true;
        }
        public static bool IsMatch(string txtPassword, string txtComPass)
        {
            return txtPassword == txtComPass;
        }



        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            bool hasUpper = false, hasNumber = false, hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsDigit(c)) hasNumber = true;
                else if (!char.IsLetterOrDigit(c)) hasSpecial = true;
            }

            return hasUpper && hasNumber && hasSpecial;
        }



    }
}
