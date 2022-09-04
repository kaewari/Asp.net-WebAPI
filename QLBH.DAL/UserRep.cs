using QLBH.Common.DAL;
using System;
using QLBH.DAL.Models;
using System.Linq;
using QLBH.Common.Rsp;
using QLBH.Common.Req;
using System.Collections.Generic;
using System.Security.Claims;

namespace QLBH.DAL
{
    public class UserRep:GenericRep<QLBHDatabaseContext, User>
    {
        public UserRoleRep userRoleRep;
        public UserRep() 
        {
            userRoleRep = new UserRoleRep();
        }
        public UserModel GetUserByID(int id)
        {          
            UserModel userModel = new UserModel();
            User user = All.SingleOrDefault(u => u.UserId == id);
            if (user == null)
                return null;
            userModel.UserId = user.UserId;
            userModel.Username = user.Username;
            userModel.FullName = user.FullName;
            userModel.Email = user.Email;
            userModel.Phone = user.Phone;
            userModel.Role = userRoleRep.GetRole(id);
            return userModel;
        }
        public SingleRsp Register(User user)
        {
            var res = new SingleRsp();
            UserRole userRole = new UserRole();
            using (var context = new QLBHDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var checkID = All.SingleOrDefault(s => s.UserId == user.UserId);
                        var checkEmail = All.Where(s => s.Email == user.Email);
                        var checkUsername = All.Where(s => s.Username == user.Username);
                        if (checkID != null)
                        {
                            res.SetError("Trùng khóa chính");
                        }
                        else
                        {
                            if (checkEmail.Count() > 0)
                            {
                                res.SetError("Email đã tồn tại");
                            }
                            else
                            {
                                if (checkUsername.Count() > 0)
                                {
                                    res.SetError("Username đã tồn tại");
                                }
                                else
                                {
                                    userRole.UserId = user.UserId;
                                    userRole.RoleId = 2;
                                    var p = context.Users.Add(user);
                                    var s = context.UserRoles.Add(userRole);
                                    context.SaveChanges();
                                    tran.Commit();
                                    res.SetMessage("Đăng ký thành công");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        res.SetError(ex.StackTrace);
                        tran.Rollback();
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new QLBHDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var checkID = All.SingleOrDefault(s => s.UserId == user.UserId);
                        var checkEmail = All.Where(s => s.Email == user.Email && s.UserId != user.UserId);
                        var checkUsername = All.Where(s => s.Username == user.Username && s.UserId != user.UserId);
                        if (checkID == null)
                        {
                            res.SetError("User không tồn tại");
                        }
                        else
                        {
                            if (checkEmail.Count() > 0)
                            {
                                res.SetError("Email đã tồn tại");                                            
                            }
                            else 
                            {
                                if (checkUsername.Count() > 0)
                                {
                                    res.SetError("Username đã tồn tại");
                                }
                                else
                                {
                                    var p = context.Users.Update(user);
                                    context.SaveChanges();
                                    tran.Commit();
                                    res.SetMessage("Cập nhật thành công");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {                       
                        res.SetError(ex.StackTrace);
                        tran.Rollback();
                    }
                }
            }
            return res;
        }
        public SingleRsp DeleteUser(int Id)
        {
            var res = new SingleRsp();
            var user = All.SingleOrDefault(i => i.UserId == Id);
            using (var context = new QLBHDatabaseContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var checkID = All.SingleOrDefault(s => s.UserId == Id);
                        if (checkID == null)
                            res.SetError("User không tồn tại");
                        else
                        {
                            var p = context.Users.Remove(user);
                            context.SaveChanges();
                            tran.Commit();
                            res.SetMessage("Xóa thành công");
                        }
                    }
                    catch (Exception ex)
                    {                       
                        res.SetError(ex.StackTrace);
                        tran.Rollback();
                    }
                }
            }
            return res;          
        }
        public SingleRsp LoginUser(User user)
        {
            var res = new SingleRsp();
            try
            {
                var p = All.SingleOrDefault(s => s.Username == user.Username);
                if (p != null)
                {
                    if (p.Password == user.Password)
                    {
                        res.SetMessage("Đăng nhập thành công");
                        
                        return res;
                    }
                    else
                    {
                        res.SetError("Mật khẩu không đúng");
                    }
                }
                else
                {
                    res.SetError("Tài khoản không đúng");
                }
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
    }
}
