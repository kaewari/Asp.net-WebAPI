using QLBH.Common.BLL;
using QLBH.DAL;
using QLBH.DAL.Models;
using QLBH.Common.Rsp;
using QLBH.Common.Req;
using System.Linq;
using System.Collections.Generic;

namespace QLBH.BLL
{
    public class UserSvc:GenericSvc<UserRep, User>
    {
        public UserRep userRep;
        public UserSvc()
        {
            userRep = new UserRep();
        }
        public SingleRsp GetUserByID(int id)
        {
            var res = new SingleRsp
            {
                Data = userRep.GetUserByID(id)
            };
            if (res.Data != null)
            {
                res.SetMessage("Thành công");
            }
            else
            {
                res.SetError("Không có user");
            }
            return res;
        }       

        public SingleRsp Register(UserReq userReq)
        {
            _ = new SingleRsp();
            User user = new User();
            user.UserId = userReq.UserId;
            user.FullName = userReq.FullName;
            user.Username = userReq.Username;
            user.Password = Encode.GetMD5(userReq.Password);
            user.Email = userReq.Email;
            user.Phone = userReq.Phone;
            SingleRsp res = userRep.Register(user);
            return res;
        }
        public SingleRsp UpdateUser(UserReq userReq)
        {
            _ = new SingleRsp();
            User user = new User();
            user.UserId = userReq.UserId;
            user.FullName = userReq.FullName;
            user.Username = userReq.Username;
            user.Password = Encode.GetMD5(userReq.Password);
            user.Email = userReq.Email;
            user.Phone = userReq.Phone;

            SingleRsp res = userRep.UpdateUser(user);
            return res;
        }
        public SingleRsp DeleteUser(int Id)
        {
            SingleRsp res = userRep.DeleteUser(Id);
            return res;
        }
        public SingleRsp LoginUser(LoginReq loginReq)
        {
            _ = new SingleRsp();
            User user = new User();
            user.Username = loginReq.Username;
            user.Password = Encode.GetMD5(loginReq.Password);
            SingleRsp res = userRep.LoginUser(user);
            return res;
        }
    }
}
