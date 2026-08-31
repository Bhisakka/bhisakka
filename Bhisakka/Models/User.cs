using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhisakka.Models
{
    internal class User
    {
        private int UserId;
        private string Username;
        private string FullName;

        private Role UserRole;

        private bool IsActive;

        public User(int UserId, string Username, string FullName, bool IsActive, Role UserRole)
        {
            this.UserId = UserId;
            this.Username = Username;
            this.FullName = FullName;
            this.UserRole = UserRole;
            this.IsActive = IsActive;
        }

        public int GetUserID()
        {
            return this.UserId;
        }

        public void SetUserId(int UserId)
        {
            this.UserId = UserId;
        }

        public string GetUsername()
        {
            return this.Username;
        }

        public void SetUsername(string Username)
        {
            this.Username = Username;
        }


        public string GetFullname()
        {
            return this.FullName;
        }

        public void SetFullname(string FullName)
        {
            this.FullName = FullName;
        }

        public Role GetUserRole()
        {
            return this.UserRole;
        }

        public void SetUserRole(Role UserRole)
        {
            this.UserRole = UserRole;
        }

        public bool GetIsActive()
        {
            return this.IsActive;
        }

        public void SetIsActive(bool IsActive)
        {
            this.IsActive = IsActive;
        }
    }
}
