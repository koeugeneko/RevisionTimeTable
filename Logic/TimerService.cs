using System;
using System.Windows.Forms;

namespace TimeTable.Logic
{
    internal class TimerService
    {
        private System.Windows.Forms.Timer _timer;
        private int _totalSeconds;
        private int _remainingSeconds;
        private bool _isRunning;

        public event Action<int> OnTick;
        public event Action OnTimerComplete;

        public TimerService()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            _totalSeconds = 25 * 60;
            _remainingSeconds = _totalSeconds;
            _isRunning = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_remainingSeconds > 0)
            {
                _remainingSeconds--;
                OnTick?.Invoke(_remainingSeconds);
            }
            else
            {
                Stop();
                OnTimerComplete?.Invoke();
            }
        }

        public void Start(int minutes)
        {
            _totalSeconds = minutes * 60;
            _remainingSeconds = _totalSeconds;
            _isRunning = true;
            _timer.Start();
        }

        public void Resume()
        {
            if (_remainingSeconds > 0)
            {
                _isRunning = true;
                _timer.Start();
            }
        }

        public void Stop()
        {
            _isRunning = false;
            _timer.Stop();
        }

        public void Reset()
        {
            Stop();
            _remainingSeconds = _totalSeconds;
            OnTick?.Invoke(_remainingSeconds);
        }

        public void AddMinutes(int minutes)
        {
            _remainingSeconds += minutes * 60;
            _totalSeconds = _remainingSeconds;
            OnTick?.Invoke(_remainingSeconds);
        }

        public int GetRemainingSeconds()
        {
            return _remainingSeconds;
        }

        public int GetTotalSeconds()
        {
            return _totalSeconds;
        }

        public bool IsRunning()
        {
            return _isRunning;
        }
    }
}
