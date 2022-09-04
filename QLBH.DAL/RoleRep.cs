using QLBH.Common.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH.DAL
{
    public class RoleRep : GenericRep<QLBHDatabaseContext, Role>
    {
        public RoleRep() {}
        public string GetRole(int id)
        {
            return All.SingleOrDefault(s => s.RoleId == id).RoleName;
        }
    }
}
