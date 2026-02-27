using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTable.Data;
using TimeTable.Logic;

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

            DisplayPlan();
        }

        private void DisplayPlan()
        {
            LinkedList<Logic.Task> dailyTasks = DailyPlanService.GenerateDailyPlan();

            dataGridView1.Columns.Clear();
            


            Debug.WriteLine($"found {dailyTasks.Count} daily tasks");

            foreach (Logic.Task task in dailyTasks) {
               
            }
            dataGridView1.DataSource = dailyTasks.ToList<Logic.Task>();
            dataGridView1.Columns["TaskId"].Visible = false;
            dataGridView1.Columns["UserId"].Visible = false;
            dataGridView1.Columns["SubjectId"].Visible = false;
            dataGridView1.Columns["CompletedAt"].Visible = false;
            dataGridView1.Columns["CreatedAt"].Visible = false;


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
