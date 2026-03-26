using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTable.Data;
using TimeTable.Logic;

namespace TimeTable.UI
{
    public partial class TimerPage : UserControl
    {
        private TimerService _timerService;
        private Logic.Task _selectedTask;
        private bool _isResumed;
        private int _currentMinutes;

        public Action NavigateBack;

        public TimerPage()
        {
            InitializeComponent();
            _timerService = new TimerService();
            _timerService.OnTick += UpdateTimerDisplay;
            _timerService.OnTimerComplete += TimerComplete;
            UpdateTimerDisplay(_timerService.GetRemainingSeconds());
        }

        public void SetTask(Logic.Task task)
        {
            _selectedTask = task;
            _isResumed = false;
            _currentMinutes = task.EstimatedMinutes;

            _timerService = new TimerService();
            _timerService.CurrentTask = task;
            _timerService.OnTick += UpdateTimerDisplay;
            _timerService.OnTimerComplete += TimerComplete;

            labelTaskName.Text = task.Description ?? "Task";
            labelTaskTime.Text = $"Estimated: {task.EstimatedMinutes} min";

            UpdateTimerDisplay(_currentMinutes * 60);
            button2.Text = "Start";
        }

        private void UpdateTimerDisplay(int seconds)
        {
            if (label1.InvokeRequired)
            {
                label1.Invoke(new Action(() => label1.Text = FormatTime(seconds)));
            }
            else
            {
                label1.Text = FormatTime(seconds);
            }
        }

        private string FormatTime(int totalSeconds)
        {
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int secs = totalSeconds % 60;

            if (hours > 0)
                return $"{hours}:{minutes:D2}:{secs:D2}";
            else
                return $"{minutes:D2}:{secs:D2}";
        }

        private void TimerComplete()
        {
            if (_selectedTask != null)
            {
                _selectedTask.Completed = true;
                _selectedTask.CompletedAt = DateTime.Now;
                _selectedTask.ActualMinutes = _selectedTask.EstimatedMinutes;
                DataLayer.UpdateTaskInDatabase(_selectedTask);

                MessageBox.Show($"Task completed!\n\n'{_selectedTask.Description}' has been marked as done.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Timer complete! Great job!", "Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            NavigateBack?.Invoke();
        }

        private void button2_Click(object sender, EventArgs e) // Start/Stop
        {
            if (_timerService.IsRunning())
            {
                _timerService.Stop();
                button2.Text = "Resume";
            }
            else
            {
                if (!_isResumed && _timerService.GetRemainingSeconds() == _timerService.GetTotalSeconds())
                {
                    _timerService.Start(_currentMinutes);
                    _isResumed = true;
                }
                else
                {
                    _timerService.Resume();
                }
                button2.Text = "Stop";
            }
        }

        private void button1_Click(object sender, EventArgs e) // Reset
        {
            _timerService.Stop();
            _isResumed = false;
            _currentMinutes = _selectedTask?.EstimatedMinutes ?? 25;
            _timerService.Start(_currentMinutes);
            button2.Text = "Start";
            UpdateTimerDisplay(_currentMinutes * 60);
        }

        private void button3_Click(object sender, EventArgs e) // Add 5 min
        {
            _timerService.AddMinutes(5);
            _currentMinutes += 5;
            UpdateTimerDisplay(_timerService.GetRemainingSeconds());
        }
    }
}
