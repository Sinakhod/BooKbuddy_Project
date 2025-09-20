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
    public partial class FrmFindPartner : Form
    {
        public FrmFindPartner()
        {
            InitializeComponent();

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

            FilterAndShowProfiles();

        }

        private void FilterAndShowProfiles()
        {
            if (cmbYear.SelectedIndex <= 0 || cmbModules.SelectedIndex < 0)
                return;

            string selectedYear = cmbYear.SelectedItem.ToString();
            string selectedCourse = cmbModules.SelectedItem.ToString();

            var filtered = ProfileStore.Profiles
                .Where(p => p.Year == selectedYear && p.Course == selectedCourse)
                .ToList();

            dataGridViewProfile.DataSource = null;
            dataGridViewProfile.DataSource = filtered;

            dataGridViewProfile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FrmHomePage().Show();
            this.Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string year = cmbYear.SelectedItem.ToString();
            string course = cmbModules.SelectedItem.ToString();

            var matches = ProfileStore.Profiles.FindAll(p => p.Year == year && p.Course == course);
            dataGridViewProfile.DataSource = null;
            dataGridViewProfile.DataSource = matches;
        }

        private void FrmFindPartner_Load(object sender, EventArgs e)
        {

        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            if (dataGridViewProfile.CurrentRow?.DataBoundItem is Profile selectedProfile)
            {
                // Replace "current user" with actual current username if available
                string currentUsername = "CurrentUser"; // Or get it from logged-in session

                RequestStore.Requests.Add(new PartnerRequest
                {
                    FromUser = currentUsername,
                    ToUser = selectedProfile.FullName,
                    RequestDate = DateTime.Now
                });

                MessageBox.Show($"Request sent to {selectedProfile.FullName}.", "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a profile first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
