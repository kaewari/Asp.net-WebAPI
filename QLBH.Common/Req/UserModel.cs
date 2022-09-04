using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.Common.Req
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Role { get; set; }
    }
}
