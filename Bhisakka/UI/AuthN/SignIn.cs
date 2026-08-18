using Bhisakka.Models;
using Bhisakka.Services;
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

namespace Bhisakka.UI.AuthN
{
    public partial class SignIn : LMaterialForm
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void TxtSubmit_Click(object sender, EventArgs e)
        {
            string Username = TxtUsername.Text.Trim();
            string Password = TxtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                if (string.IsNullOrWhiteSpace(Username))
                {
                    TxtUsername.IsError = true;
                    TxtUsername.ErrorText = "Username cannot be empty";
                }
                
                if (string.IsNullOrEmpty(Password))
                {
                    TxtPassword.IsError = true;
                    TxtPassword.ErrorText = "Password cannot be empty";
                }

                LMaterialDialog.Show(this, "Cannot be empty", "Username | Password cannot be empty");
            }
            else
            {
                AuthService AuthNService = new AuthService();
                User CurrentUser = AuthNService.Authenticate(Username, Password);
                int RoleId = CurrentUser.GetUserRole().GetRoleId();

                switch (RoleId)
                {
                    case 1:
                        // You are a Doctor
                        break;
                    case 2:
                        // You are a Receptionist
                        break;
                    case 3:
                        // You are a Pharmacist
                        break;
                    default:
                        // Unknown role - database corrupted
                        break;
                }
            }
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            TxtUsername.IsError = false;
            TxtUsername.ErrorText = string.Empty;
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            TxtPassword.IsError = false;
            TxtPassword.ErrorText = string.Empty;
        }
    }
}
