using QLBH.Common.Req;

namespace QLBH
{
    public interface ITokenService
    {
        public string CreateToken(UserModel user);
    }
}
