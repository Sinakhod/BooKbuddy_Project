using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuddyProject2._0
{
    internal class Login
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        public static void SetUser(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public static void ClearUser()
        {
            Username = null;
            Password = null;
        }
    }
}
