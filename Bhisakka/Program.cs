using Bhisakka.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bhisakka
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new WindowManagerTestForm1();
            WindowManager.GetInstance().RegisterForm(mainForm);

            Application.Run(mainForm);

            //string PasswordTesting = "Enter your password";
            //Console.WriteLine(PasswordTesting);
        }
    }
}
