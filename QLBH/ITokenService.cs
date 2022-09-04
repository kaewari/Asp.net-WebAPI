using QLBH.Common.Req;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH
{
    public interface ITokenService
    {
        public string CreateToken(UserModel user);
    }
}
