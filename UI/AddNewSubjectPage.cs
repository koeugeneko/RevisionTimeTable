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
    public partial class AddNewSubjectPage : UserControl
    {
        public AddNewSubjectPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string subjectName = textBox1.Text;
            Logic.SubjectService.AddNewTask(subjectName);
        }
    }
}
