using Bhisakka.Util;
using System;
using System.Windows.Forms;

namespace Bhisakka
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new UI.AuthN.SignIn();
            WindowManager.GetInstance().RegisterForm(mainForm);

            Application.Run(mainForm);
        }
    }
}
