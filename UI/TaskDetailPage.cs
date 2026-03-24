using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTable.Logic;

namespace TimeTable.UI
{
    public partial class TaskDetailPage : UserControl
    {
        private Logic.Task _currentTask;

        public TaskDetailPage()
        {
            InitializeComponent();
        }

        public void SetTask(Logic.Task task)
        {
            _currentTask = task;
            LoadTaskData();
        }

        private void LoadTaskData()
        {
            if (_currentTask == null) return;
        }

        public Action backButtonClicked;
        private void buttonBack_Click(object sender, EventArgs e)
        {
            backButtonClicked?.Invoke();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_currentTask != null)
            {
                TaskService.UpdateTask(_currentTask);
                MessageBox.Show("Task updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                backButtonClicked?.Invoke();
            }
        }
    }
}
