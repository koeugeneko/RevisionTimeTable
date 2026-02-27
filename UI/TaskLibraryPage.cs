using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

            Debug.WriteLine($"found {tasks.Count} subjects");

            dataGridView1.DataSource = tasks;
            dataGridView1.Columns["UserId"].Visible = false;
            dataGridView1.Columns["TaskId"].Visible = false;
            dataGridView1.Columns["SubjectId"].Visible = false;
            //dataGridView1.Columns["Completed"].ReadOnly = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void TaskLibraryPage_Load(object sender, EventArgs e)
        {
            DisplayTasks();
        }

        private void TaskLibraryPage_VisibleChanged(object sender, EventArgs e)
        {
            DisplayTasks();
        }

        private void DeleteTaskButton_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedTask = (Logic.Task)dataGridView1.SelectedRows[0].DataBoundItem;

                int taskId = selectedTask.TaskId;
                TaskService.DeleteTask(taskId);
            }

            DisplayTasks(); // refresh
        }

        private void EditTaskButton_Click(object sender, EventArgs e)
        {
            //TaskService.UpdateTask();
        }
    }
}
