using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
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

        private void loadTaskDisplay()
        {
            dataGridView1.Columns.Clear();

            var tasks = TaskService.GetTasksForCurrentUser();

           

            Debug.WriteLine($"found {tasks.Count} subjects");

            dataGridView1.DataSource = tasks;


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void TaskLibraryPage_Load(object sender, EventArgs e)
        {
            loadTaskDisplay();
        }
    }
}
