using Bhisakka.Util;
using MaterialComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bhisakka
{
    public partial class HashingTest : LMaterialForm
    {
        public HashingTest()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LblHashed.Text = CryptoUtil.ComputeSha256Hash(TxtRaw.Text);
        }
    }
}
