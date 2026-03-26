using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTable.Data;
using TimeTable.Logic;

namespace TimeTable.UI
{
    public partial class DailyTaskPage : UserControl
    {
        public Action<Logic.Task> NavigateToTimer;

        public DailyTaskPage()
        {
            InitializeComponent();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedTask = (Logic.Task)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                NavigateToTimer?.Invoke(selectedTask);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }
        private void DailyTaskPage_Load(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            lblDate.Text = $"{now:dd/MM/yyyy} {now.DayOfWeek}";

            DisplayPlan();
        }

        private void DisplayPlan()
        {
            LinkedList<Logic.Task> dailyTasks = DailyPlanService.GenerateDailyPlan();

            dataGridView1.Columns.Clear();

            Debug.WriteLine($"found {dailyTasks.Count} daily tasks");

            dataGridView1.DataSource = dailyTasks.ToList<Logic.Task>();
            dataGridView1.Columns["TaskId"].Visible = false;
            dataGridView1.Columns["UserId"].Visible = false;
            dataGridView1.Columns["SubjectId"].Visible = false;
            dataGridView1.Columns["CompletedAt"].Visible = false;
            dataGridView1.Columns["CreatedAt"].Visible = false;
            dataGridView1.Columns["ActualMinutes"].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedTask = (Logic.Task)dataGridView1.SelectedRows[0].DataBoundItem;
                selectedTask.Completed = true;
                selectedTask.CompletedAt = DateTime.Now;
                DataLayer.UpdateTaskInDatabase(selectedTask);
                DisplayPlan();
                MessageBox.Show("Task marked as complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a task to mark as complete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
