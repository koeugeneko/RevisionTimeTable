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
        private void button2_Click(object sender, EventArgs e)
        {
            TaskService.AddNewTask();
            confirmButtonClicked?.Invoke();
        }
    }
}
