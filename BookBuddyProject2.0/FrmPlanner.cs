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
    public partial class FrmPlanner : Form
    {
        private List<TaskItem> taskList = new List<TaskItem>();

        public FrmPlanner()
        {
            InitializeComponent();

            cmbPriority.Items.Clear();
            cmbPriority.Items.Add("Low");
            cmbPriority.Items.Add("Average");
            cmbPriority.Items.Add("High");

            cmbPriority.SelectedIndex = 0;
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;

            dataGridViewPlanner.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please enter a task title.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaskItem task = new TaskItem
            {
                Title = txtTaskTitle.Text,
                DueDate = dtpDueDate.Value,
                Priority = cmbPriority.SelectedItem.ToString(),
                Notes = rtbNotes.Text
            };

            taskList.Add(task);
            UpdateTaskGrid();


            txtTaskTitle.Clear();
            rtbNotes.Clear();
            cmbPriority.SelectedIndex = 0;
            dtpDueDate.Value = DateTime.Now;
        }


        private void UpdateTaskGrid()
        {
            dataGridViewPlanner.DataSource = null;
            dataGridViewPlanner.DataSource = taskList;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            new FrmHomePage().Show();
            this.Hide(); 
        }

        
    }
}
