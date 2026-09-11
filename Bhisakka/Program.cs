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

            Audio.AmbianceService.Initialize();

            var signInForm = new UI.AuthN.SignIn();
            WindowManager.GetInstance().RegisterForm(signInForm);
            signInForm.Show();

            Application.Run();
        }
    }
}
