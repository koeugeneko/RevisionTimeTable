using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTable.Logic;

namespace TimeTable.UI
{
    public partial class TaskLibraryPage : UserControl
    {
        public TaskLibraryPage()
        {
            InitializeComponent();
        }

        public Action addNewTaskButtonClicked;
        private void AddNewTask_Click(object sender, EventArgs e)
        {
            addNewTaskButtonClicked?.Invoke();
        }

        private void DisplayTasks()
        {
            dataGridView1.Columns.Clear();

            var tasks = TaskService.GetTasksForCurrentUser();

            var displayList = tasks.Select(t => new
            {
                Description = t.Description,
                Time = t.EstimatedMinutes,
                Priority = t.Priority,
                DueDate = t.DueDate,
                Completed = t.Completed,
                //Completed_At = t.CompletedAt,
                //Created_At = t.CreatedAt,
            }).ToList();

            Debug.WriteLine($"found {tasks.Count} subjects");

            dataGridView1.DataSource = displayList;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void TaskLibraryPage_Load(object sender, EventArgs e)
        {
            DisplayTasks();
        }
    }
}
