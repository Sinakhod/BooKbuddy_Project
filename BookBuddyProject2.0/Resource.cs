using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuddyProject2._0
{
    internal class SharedResource
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Year { get; set; }       // "1st Year", "2nd Year", "3rd Year"
        public string Module { get; set; }     // e.g. "Information Systems"
        public bool IsApproved { get; set; }   // For admin approval
    }
}
