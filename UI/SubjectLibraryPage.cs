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
using TimeTable.Logic;

namespace TimeTable.UI
{
    public partial class SubjectLibraryPage : UserControl
    {
        public SubjectLibraryPage()
        {
            InitializeComponent();
        }

        public event Action AddSubjectButtonClicked;
        private void AddNewSubject_Click(object sender, EventArgs e)
        {
            AddSubjectButtonClicked?.Invoke();

        }
        private void button1_Click(object sender, EventArgs e)// delete subject
        {       

            SubjectService.DeleteSubject(dataGridView1.CurrentRow.Cells["Name"].Value.ToString());
            DisplaySubjects(); // refresh
        }

        private void DisplaySubjects()
        {
            dataGridView1.Columns.Clear();

            var subjects = SubjectService.GetSubjectsForCurrentUser();

            Debug.WriteLine($"found {subjects.Count} subjects");

            dataGridView1.DataSource = subjects;
            dataGridView1.Columns["UserId"].Visible = false;
            dataGridView1.Columns["SubjectId"].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }



        private void SubjectLibraryPage_Load(object sender, EventArgs e)
        {
            DisplaySubjects();
        }

        private void SubjectLibraryPage_VisibleChanged(object sender, EventArgs e)
        {
            DisplaySubjects();
        }
    }
}
