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
    public partial class DailyTaskPage : UserControl
    {
        public DailyTaskPage()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }
        private void DailyTaskPage_Load(object sender, EventArgs e)
        {
            // set date time
            var now = DateTime.Now;
            lblDate.Text = $"{now:dd/MM/yyyy} {now.DayOfWeek}";

            Logic.DailyPlanService.CallPublicHolidayApi();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
