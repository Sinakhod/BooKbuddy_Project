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
    public partial class FrmStudyGroup : Form
    {
        public FrmStudyGroup()
        {
            InitializeComponent();
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string formattedMessage = $"[{timestamp}] {txtSender.Text} in {txtGroup.Text}: {txtMessage.Text}";
            Chat.Items.Add(formattedMessage);
            txtMessage.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FrmHomePage().Show();
            this.Hide(); 
        }

        private void Chat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

