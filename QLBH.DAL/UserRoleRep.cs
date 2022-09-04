using QLBH.Common.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH.DAL
{
    public class UserRoleRep : GenericRep<QLBHDatabaseContext, UserRole>
    {
        public RoleRep roleRep;
        public UserRoleRep() 
        {
            roleRep = new RoleRep();
        }
        public string GetRole(int id)
        {        
            return roleRep.GetRole(All.SingleOrDefault(s => s.UserId == id).RoleId);
        }
    }
}
