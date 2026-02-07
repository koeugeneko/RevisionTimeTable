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
        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
