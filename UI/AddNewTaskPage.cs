using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTable.Data;
using TimeTable.Logic;


namespace TimeTable.UI
{
    public partial class AddNewTaskPage : UserControl
    {
        public AddNewTaskPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddNewTaskPage_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public event Action confirmButtonClicked;
        private void button2_Click(object sender, EventArgs e) //confirm
        {
            TaskService.AddNewTask();
            confirmButtonClicked?.Invoke();
        }

        private void comboBox1_Click(object sender, EventArgs e) //subject
        {
            var dt = new DataTable();
            dt.Columns.Add("SubjectId", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            var subjects = TaskService.GetSubjectsForCurrentUser();
            Debug.WriteLine($"Found {subjects.Count} subjects");
            foreach (var s in subjects)
            {
                dt.Rows.Add(s.SubjectId, s.Name);
            }

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "SubjectId";
        }
    }
}
