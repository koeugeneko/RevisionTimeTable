using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TimeTable.Data;
using TimeTable.Logic;

namespace TimeTable.UI
{
    public partial class ReportStatsPage : UserControl
    {
        private int _currentUserId;

        public ReportStatsPage()
        {
            InitializeComponent();
        }

        private void DisplayTaskProgressChart()
        {
            // TODO: Implement pie chart for completed vs pending tasks
            // Use: formsPlot1.Plot.Add.Pie(...)
            formsPlot1.Plot.Title("Click to view task progress");
            formsPlot1.Refresh();
        }

        private void DisplaySubjectProgressChart(string subjectName)
        {
            // TODO: Implement bar chart for subject time
            formsPlot1.Plot.Title($"Click to view: {subjectName}");
            formsPlot1.Refresh();
        }

        private void DisplayWeeklyProgressChart()
        {
            // TODO: Implement weekly progress chart
            formsPlot1.Plot.Title("Click to view weekly progress");
            formsPlot1.Refresh();
        }

        private void DisplayReport()
        {
            _currentUserId = CurrentUser.UserId;

            int totalTasks = DataLayer.GetTotalTaskCount(_currentUserId);
            int completedTasks = DataLayer.GetCompletedTaskCount(_currentUserId);
            int overdueTasks = DataLayer.GetOverdueTaskCount(_currentUserId);
            int totalMinutes = DataLayer.GetTotalStudyMinutes(_currentUserId);
            int totalSubjects = DataLayer.GetTotalSubjectCount(_currentUserId);

            double completionRate = totalTasks > 0 ? (double)completedTasks / totalTasks * 100 : 0;

            int hours = totalMinutes / 60;
            int mins = totalMinutes % 60;
            string totalTimeStr = hours > 0 ? $"{hours}h {mins}m" : $"{mins}m";

            Dictionary<string, string> taskReport = new();
            taskReport.Add("Total study time", totalTimeStr);
            taskReport.Add("Total tasks", totalTasks.ToString());
            taskReport.Add("Completed tasks", completedTasks.ToString());
            taskReport.Add("Overdue tasks", overdueTasks.ToString());
            taskReport.Add("Completion rate", $"{completionRate:F1}%");

            Dictionary<string, string> subjectReport = new();
            subjectReport.Add("Total subjects", totalSubjects.ToString());

            var subjectTimeStats = DataLayer.GetSubjectTimeStats(_currentUserId);
            foreach (var subject in subjectTimeStats)
            {
                int subHours = subject.Value / 60;
                int subMins = subject.Value % 60;
                string subTimeStr = subHours > 0 ? $"{subHours}h {subMins}m" : $"{subMins}m";
                subjectReport.Add(subject.Key, subTimeStr);
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = taskReport.ToList();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = subjectReport.ToList();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;

            dataGridView3.Columns.Clear();
            dataGridView3.DataSource = taskReport.ToList();
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.ColumnHeadersVisible = false;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.MultiSelect = false;

            DisplayTaskProgressChart();
        }

        private void ReportStatsPage_Load(object sender, EventArgs e)
        {
            DisplayReport();
        }

        private void ReportStatsPage_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                DisplayReport();
            }
        }
    }
}
