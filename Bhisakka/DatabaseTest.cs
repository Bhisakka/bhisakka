using Bhisakka.DataAccess;
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
    public partial class DatabaseTest : LMaterialForm
    {
        public DatabaseTest()
        {
            InitializeComponent();
        }

        private void lbtn_db_version_Click(object sender, EventArgs e)
        {
            string testResult = DatabaseTester.PingDatabase();
            LMaterialDialog.Show(this, "Local Database Test", testResult);
        }
    }
}
