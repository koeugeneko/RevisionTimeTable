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
    public partial class TimerPage : UserControl
    {
        private TimerService _timerService;

        public TimerPage()
        {
            InitializeComponent();
            _timerService = new TimerService();
            _timerService.OnTick += UpdateTimerDisplay;
            _timerService.OnTimerComplete += TimerComplete;
            UpdateTimerDisplay(_timerService.GetRemainingSeconds());
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
            MessageBox.Show("Timer complete! Great job!", "Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e) // Start
        {
            if (_timerService.IsRunning())
            {
                _timerService.Stop();
                button2.Text = "Start";
            }
            else
            {
                if (_timerService.GetRemainingSeconds() == _timerService.GetTotalSeconds())
                {
                    _timerService.Start(25);
                }
                else
                {
                    _timerService.Resume();
                }
                button2.Text = "Stop";
            }
        }

        private void button1_Click(object sender, EventArgs e) // Stop/Reset
        {
            _timerService.Reset();
            button2.Text = "Start";
            UpdateTimerDisplay(_timerService.GetRemainingSeconds());
        }

        private void button3_Click(object sender, EventArgs e) // Add 5 min
        {
            _timerService.AddMinutes(5);
            UpdateTimerDisplay(_timerService.GetRemainingSeconds());
        }
    }
}
