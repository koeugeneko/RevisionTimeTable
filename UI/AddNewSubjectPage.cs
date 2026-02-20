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
        public event Action confirmButtonClicked;

        private void button1_Click(object sender, EventArgs e) // add new subject button
        {   
            bool success = SubjectService.AddNewSubject(textBox1.Text);
            confirmButtonClicked?.Invoke();
            if (!success)
            {
                MessageBox.Show("A subject with this name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewSubjectPage_VisibleChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox1.Focus();
        }
    }
}
