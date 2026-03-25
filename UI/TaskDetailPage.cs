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

            textBoxDescription.Text = _currentTask.Description ?? "";
            numericUpDownPriority.Value = _currentTask.Priority > 0 ? _currentTask.Priority : 1;
            numericUpDownEstimatedTime.Value = _currentTask.EstimatedMinutes > 0 ? _currentTask.EstimatedMinutes : 30;
            
            if (_currentTask.DueDate.HasValue)
            {
                dateTimePickerDueDate.Value = _currentTask.DueDate.Value;
            }
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
                _currentTask.Description = textBoxDescription.Text;
                _currentTask.Priority = Convert.ToInt32(numericUpDownPriority.Value);
                _currentTask.EstimatedMinutes = Convert.ToInt32(numericUpDownEstimatedTime.Value);
                _currentTask.DueDate = dateTimePickerDueDate.Value;

                TaskService.UpdateTask(_currentTask);
                MessageBox.Show("Task updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                backButtonClicked?.Invoke();
            }
        }
    }
}
