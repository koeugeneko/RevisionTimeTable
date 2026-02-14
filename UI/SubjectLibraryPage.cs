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
            SubjectService.DeleteTask(dataGridView1.SelectedCells.ToString());
        }

        private void DisplaySubjects()
        {
            dataGridView1.Columns.Clear();

            var subjects = SubjectService.GetSubjectsForCurrentUser();

            var displayList = subjects.Select(s => new
            {
                Name = s.Name
            }).ToList();

            Debug.WriteLine($"found {subjects.Count} subjects");

            dataGridView1.DataSource = displayList;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void SubjectLibraryPage_Load(object sender, EventArgs e)
        {
            DisplaySubjects();
        }

    }
}
