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
    public partial class ReportStatsPage : UserControl
    {
        public ReportStatsPage()
        {
            InitializeComponent();
        }

        private void DisplayReport()
        {
            Dictionary<string, string> taskReport = new();
            Dictionary<string, string> subjectReport = new();

            taskReport.Add("Total time", "20 hurs 30 min"); //testing data
            taskReport.Add("Total tasks", 10.ToString());
            taskReport.Add("Finished tasks", 12.ToString());
            taskReport.Add("Overdue tasks", 2.ToString());
            taskReport.Add("Completion rate", "20%");
            
            subjectReport.Add("Total subjects", 10.ToString());  // testing datas
            subjectReport.Add("total time on subject 1", "1 hur 10 min");

            // data grid view settings
            {
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
            }

        }

        private void ReportStatsPage_Load(object sender, EventArgs e)
        {
            DisplayReport();
        }


    }
}
