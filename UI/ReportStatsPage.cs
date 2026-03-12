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
            Dictionary<string, string> report = new();

            report.Add("Total tasks", 10.ToString());
            report.Add("Finished tasks", 12.ToString());
            report.Add("Completion rate", "20%");
            report.Add("Total subjects", 10.ToString());
            //report.Add("")

            dataGridView1.Columns.Clear();

            dataGridView1.DataSource = report.ToList();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void ReportStatsPage_Load(object sender, EventArgs e)
        {
            DisplayReport();
        }
    }
}
