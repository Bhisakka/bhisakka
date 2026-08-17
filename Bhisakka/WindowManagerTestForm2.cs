using Bhisakka.Util;
using MaterialComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bhisakka
{
    public partial class WindowManagerTestForm2 : LMaterialForm
    {
        public WindowManagerTestForm2()
        {
            InitializeComponent();
        }

        private void BtnGoBack_Click(object sender, EventArgs e)
        {
            WindowManager.GetInstance().Show<WindowManagerTestForm1>();
            WindowManager.GetInstance().Close<WindowManagerTestForm2>();
        }
    }
}
