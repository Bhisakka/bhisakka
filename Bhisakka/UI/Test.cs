using Bhisakka.DataAccess;
using System;
using System.Windows.Forms;

namespace Bhisakka.UI
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void btn_pingdb_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DatabaseTester.PingDatabase(), "GCP Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
