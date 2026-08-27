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

            var mainForm = new UI.ConsultationForm();
            WindowManager.GetInstance().RegisterForm(mainForm);

            Application.Run(mainForm);
        }
    }
}
