using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookBuddyProject2._0
{
    public partial class FrmAdminSharedResoureces : Form
    {
        public FrmAdminSharedResoureces()
        {
            InitializeComponent();

            cmbYear.Items.AddRange(new[] { "All Documents", "1st Year", "2nd Year", "3rd Year" });
            cmbYear.SelectedIndex = 0;
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModules.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvResources.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResources.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResources.MultiSelect = false;

            cmbYear.SelectedIndexChanged += cmbYear_SelectedIndexChanged;

            UpdateGrid();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateModuleList();
            UpdateGrid();
        }

        private void UpdateModuleList()
        {
            cmbModules.Items.Clear();

            if (cmbYear.SelectedItem.ToString() == "1st Year")
            {
                cmbModules.Items.AddRange(new[]
                {
                    "Development Software 1",
                    "System Software",
                    "Information System 1",
                    "Information Technology Skills"
                });
            }
            else if (cmbYear.SelectedItem.ToString() == "2nd Year")
            {
                cmbModules.Items.AddRange(new[]
                {
                    "Development Software 2",
                    "Human Computer Technology",
                    "Information Technology 2",
                    "Technical Programming"
                });
            }
            else if (cmbYear.SelectedItem.ToString() == "3rd Year")
            {
                cmbModules.Items.AddRange(new[]
                {
                    "Development Software 3",
                    "Information Technology 3",
                    "Technical Programming 2"
                });
            }
        }

        private void UpdateGrid()

        {
            string year = cmbYear.SelectedItem?.ToString();
            string module = cmbModules.SelectedItem?.ToString();

            var filtered = ResourcesStore.Resources
                .Where(r =>
                    (year == "All Documents" || r.Year == year) &&
                    (string.IsNullOrEmpty(module) || r.Module == module))
                .ToList();

            dgvResources.DataSource = null;
            dgvResources.DataSource = filtered;
        }

        private void bntApprove_Click(object sender, EventArgs e)
        {
            if (dgvResources.CurrentRow?.DataBoundItem is SharedResource selected)
            {
                selected.IsApproved = true;
                MessageBox.Show("Resource approved.");
                UpdateGrid();
            }
        }

        private void bntUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFile.FileName);
                string resourcePath = Path.Combine(Application.StartupPath, "Resources");

                if (!Directory.Exists(resourcePath))
                    Directory.CreateDirectory(resourcePath);

                string destPath = Path.Combine(resourcePath, fileName);
                File.Copy(openFile.FileName, destPath, true);

                ResourcesStore.Resources.Add(new SharedResource
                {
                    FileName = fileName,
                    FilePath = destPath,
                    Year = cmbYear.SelectedItem?.ToString() ?? "Unknown",
                    Module = cmbModules.SelectedItem?.ToString() ?? "Unknown",
                    IsApproved = true
                });

                MessageBox.Show("Resource uploaded successfully.");
                UpdateGrid();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvResources.CurrentRow?.DataBoundItem is SharedResource selected)
            {
                if (File.Exists(selected.FilePath))
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = selected.FilePath,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Could not open file.\n{ex.Message}", "View Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The file no longer exists at the saved path.");
                }
            }
            else
            {
                MessageBox.Show("Please select a resource first.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FrmAdminHomePage().Show();
            this.Hide(); 
        }

        private void cmbModules_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
