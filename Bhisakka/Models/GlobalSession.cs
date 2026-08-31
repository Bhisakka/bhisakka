using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhisakka.Models
{
    internal class GlobalSession
    {
        private static User CurrentUser;

        public static void Login(User CurrentUser)
        {
            GlobalSession.CurrentUser = CurrentUser;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static User GetCurrentUser()
        {
            return CurrentUser;
        }
    }
}
