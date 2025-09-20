using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BookBuddyProject2._0
{
    internal class UserCredentials
    {
        public static string Username { get; set; } = "user@mywsu.ac.za";
        public static string Password { get; set; } = "";


        // Method to update username and password
        public static void SetCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        //reset(for logout)
        public static void Clear()
        {
            Username = "";
            Password = "";
        }
    }
}
