using Bhisakka.Util;
using System;
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

            var mainForm = new UI.AuthN.SignIn();
            WindowManager.GetInstance().RegisterForm(mainForm);

            Application.Run(mainForm);

            //string PasswordTesting = "Enter your password";
            //Console.WriteLine(PasswordTesting);
        }
    }
}
