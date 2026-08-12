using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bhisakka.Models
{
    internal class Role
    {
        private int RoleId;
        private string RoleName;

        public Role(int RoleId, string RoleName)
        {
            this.RoleId = RoleId;
            this.RoleName = RoleName;
        }
       
        public int GetRoleId()
        {
            return this.RoleId;
        }
        
        public void SetRoleId(int RoleId)
        {
            this.RoleId=RoleId;
        }

        public string GetRoleName()
        {
            return this.RoleNamepublic void SetRoleId(int RoleId)
            {
                this.RoleId = RoleId;
            }

        }
    }
}
