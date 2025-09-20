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
    public partial class FrmProfileDesign : Form
    {
        public FrmProfileDesign()
        {
            InitializeComponent();

            cmbTime.Items.Clear();
            cmbTime.Items.Add("Mornings");
            cmbTime.Items.Add("Afternoons");
            cmbTime.Items.Add("Evenings");
            cmbTime.SelectedIndex = 0;
            cmbTime.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYear.Items.Clear();
            cmbYear.Items.Add("Select Year Of Study");
            cmbYear.Items.Add("1st Year");
            cmbYear.Items.Add("2nd Year");
            cmbYear.Items.Add("3rd Year");
            cmbYear.SelectedIndex = 0;

            cmbModules.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbYear.SelectedIndexChanged += cmbYear_SelectedIndexChanged;
        }
        private void cmbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYear.SelectedIndex == 0)
            {
                cmbModules.Items.Clear();
                return;
            }

            cmbModules.Items.Clear();

            if (cmbYear.SelectedItem.ToString() == "1st Year")
            {
                cmbModules.Items.Add("Development Software 1");
                cmbModules.Items.Add("System Software");
                cmbModules.Items.Add("Information System 1");
                cmbModules.Items.Add("Information Technology Skills");
            }
            else if (cmbYear.SelectedItem.ToString() == "2nd Year")
            {
                cmbModules.Items.Add("Development Software 2");
                cmbModules.Items.Add("Human Computer Technology");
                cmbModules.Items.Add("Information Technology 2");
                cmbModules.Items.Add("Technical Programming");
            }
            else if (cmbYear.SelectedItem.ToString() == "3rd Year")
            {
                cmbModules.Items.Add("Development Software 3");
                cmbModules.Items.Add("Information Technology 3");
                cmbModules.Items.Add("Technical Programming 2");
            }

            if (cmbModules.Items.Count > 0)
                cmbModules.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || cmbYear.SelectedIndex <= 0 || cmbModules.SelectedIndex == -1 || cmbTime.SelectedIndex == -1)
            {
                MessageBox.Show("Please complete all fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtFullName.Text.Trim();
            string year = cmbYear.SelectedItem.ToString();
            string course = cmbModules.SelectedItem.ToString();
            string time = cmbTime.SelectedItem.ToString();

            MessageBox.Show($"Saved:\n\nName: {name}\nYear: {year}\nCourse: {course}\nPreferred Time: {time}","Profile Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);


            ProfileStore.Profiles.Add(new Profile
            {
                FullName = txtFullName.Text.Trim(),
                Year = cmbYear.SelectedItem.ToString(),
                Course = cmbModules.SelectedItem.ToString(),
                PreferredTime = cmbTime.SelectedItem.ToString()
            });

            MessageBox.Show("Profile saved!");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmHomePage().Show();
            this.Hide(); 
        }

        
    }

}
