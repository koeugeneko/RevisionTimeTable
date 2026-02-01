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
    public partial class SideBarTop : UserControl
    {
        public SideBarTop()
        {
            InitializeComponent();
        }

        public event Action MinSideBarButtonClicked;

        private void MinSideBarButton_Click(object sender, EventArgs e)
        {
            MinSideBarButtonClicked?.Invoke();
        }
    }
}
