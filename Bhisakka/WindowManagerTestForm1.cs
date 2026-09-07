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
    public partial class WindowManagerTestForm1 : LMaterialForm
    {
        public WindowManagerTestForm1()
        {
            InitializeComponent();
        }

        private void BtnGoNext_Click(object sender, EventArgs e)
        {
            WindowManager.GetInstance().Show<WindowManagerTestForm2>();
            WindowManager.GetInstance().Hide<WindowManagerTestForm1>();
        }
    }
}
