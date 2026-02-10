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



        public event Action confirmButtonClicked;
        private void buttonConfirm_Click(object sender, EventArgs e) // confirm
        {
            TaskService.AddNewTask();
            confirmButtonClicked?.Invoke();
        }

        private void comboBoxSubject_Click(object sender, EventArgs e) // subject
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

            comboBoxSubject.DataSource = dt;
            comboBoxSubject.DisplayMember = "Name";
            comboBoxSubject.ValueMember = "SubjectId";
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Debug.WriteLine(monthCalendarDueDate.SelectionStart.ToString());
        }

        private void buttonClear_Click(object sender, EventArgs e) // clear
        {
            comboBoxSubject.Text = string.Empty;
            textBoxEstamiatedTime.Text = string.Empty;
            numericUpDownPriority.Value = 0;
            textBoxDescription.Text = string.Empty;
            monthCalendarDueDate.Text = string.Empty;
        }
    }
}
