using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookBuddyProject2._0
{
    public partial class FrmSharedResources : Form
    {
        public FrmSharedResources()
        {
            InitializeComponent();

            cmbYear.Items.AddRange(new[] { "1st Year", "2nd Year", "3rd Year" });
            cmbYear.SelectedIndex = 0;
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModules.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbYear.SelectedIndexChanged += cmbYear_SelectedIndexChanged;
            cmbYear_SelectedIndexChanged(null, null); // Load default module list

            // Setup DataGridView
            dgvResources.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UpdateGrid();
        }


        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbModules.Items.Clear();

            switch (cmbYear.SelectedItem.ToString())
            {
                case "1st Year":
                    cmbModules.Items.AddRange(new[]
                    {
                        "Development Software 1",
                        "System Software",
                        "Information System 1",
                        "Information Technology Skills"
                    });
                    break;

                case "2nd Year":
                    cmbModules.Items.AddRange(new[]
                    {
                        "Development Software 2",
                        "Human Computer Technology",
                        "Information Technology 2",
                        "Technical Programming"
                    });
                    break;

                case "3rd Year":
                    cmbModules.Items.AddRange(new[]
                    {
                        "Development Software 3",
                        "Information Technology 3",
                        "Technical Programming 2"
                    });
                    break;
            }

            cmbModules.SelectedIndex = 0;
        } 
        

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (cmbYear.SelectedItem == null || cmbModules.SelectedItem == null)
            {
                MessageBox.Show("Please select both year and module.", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog.FileName);
                string resourceFolder = Path.Combine(Application.StartupPath, "Resources");

                if (!Directory.Exists(resourceFolder))
                    Directory.CreateDirectory(resourceFolder);

                string destPath = Path.Combine(resourceFolder, fileName);
                File.Copy(openFileDialog.FileName, destPath, true);

                ResourcesStore.Resources.Add(new SharedResource
                {
                    FileName = fileName,
                    FilePath = destPath,
                    Year = cmbYear.SelectedItem.ToString(),
                    Module = cmbModules.SelectedItem.ToString(),
                    IsApproved = false
                });

                MessageBox.Show("File uploaded successfully. Awaiting admin approval.");
                UpdateGrid();
            }
        }
        private void UpdateGrid()
        {
            var filtered = ResourcesStore.Resources
                .Where(r => r.IsApproved
                         && r.Year == cmbYear.SelectedItem?.ToString()
                         && r.Module == cmbModules.SelectedItem?.ToString())
                .ToList();

            dgvResources.DataSource = null;
            dgvResources.DataSource = filtered;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvResources.CurrentRow?.DataBoundItem is SharedResource selectedRow)
            {
                if (File.Exists(selectedRow.FilePath))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = selectedRow.FileName;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(selectedRow.FilePath, saveFileDialog.FileName, true);
                        MessageBox.Show("File downloaded successfully.");
                    }
                }
                else
                {
                    MessageBox.Show("File not found on system.");
                }
            }

        }

        private void bntSaveNotes_Click(object sender, EventArgs e)
        {
            string notesPath = Path.Combine(Application.StartupPath, "StudentNotes.txt");
            File.WriteAllText(notesPath, rtbNotes.Text);
            MessageBox.Show("Notes saved locally.");
        }

        private void LoadNotes()
        {
            string notesPath = Path.Combine(Application.StartupPath, "StudentNotes.txt");
            if (File.Exists(notesPath))
            {
                rtbNotes.Text = File.ReadAllText(notesPath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmHomePage().Show();
            this.Hide(); 
        }

        
    }
}
