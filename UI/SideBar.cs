using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTable.UI
{
    public partial class SideBar : UserControl
    {
        public SideBar()
        {
            InitializeComponent();
        }

        public event Action DailyTaskButtonClicked; //set up a event
        private void DailyTaskButton_Click(object sender, EventArgs e)
        {
            DailyTaskButtonClicked?.Invoke();
        }

        public event Action TaskLibraryButtonClicked;
        private void TaskLibraryButton_Click(object sender, EventArgs e)
        {
            TaskLibraryButtonClicked?.Invoke();
        }

        public event Action SubjectLibraryButtonClicked;
        private void SubjectLibraryButton_Click(object sender, EventArgs e)
        {
            SubjectLibraryButtonClicked?.Invoke();
        }

        public event Action ReportStatButtonClicked;
        private void ReportStatButton_Click(object sender, EventArgs e)
        {
            ReportStatButtonClicked?.Invoke();
        }

        public event Action TimerButtonClicked;
        private void TimerButton_Click(object sender, EventArgs e)
        {
            TimerButtonClicked?.Invoke();
        }

        public event Action SettingButtonClicked;
        private void SettingButton_Click(object sender, EventArgs e)
        {
            SettingButtonClicked?.Invoke();
        }

    }
}
