using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QLBH.BLL;
using QLBH.Common.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using QLBH.Common.DAL;

namespace QLBH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public ITokenService _tokenService;
        public UserSvc userSvc;
        public UserController(ITokenService tokenService)
        {
            userSvc = new UserSvc();
            _tokenService = tokenService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Get-All-User")]
        public IActionResult GetAllUser()
        {
            var res = new SingleRsp();
            res.Data = userSvc.All.Select(s => new 
                {s.UserId, s.FullName, s.Username, s.Email, 
                s.Phone, s.UserRoles.SingleOrDefault(u=>u.UserId == s.UserId).Role.RoleName});
            if (res.Data != null)
            {
                res.SetMessage("Thành công");
            }
            else
            {
                res.SetError("Không có user");
            }
            return Ok(res);
        }
        [Authorize]
        [HttpGet("{Id:int}")]
        public IActionResult GetUserByID(int Id)
        {
            SimpleReq simpleReq = new SimpleReq();
            simpleReq.Id = Id;
            _ = new SingleRsp();
            SingleRsp res = userSvc.GetUserByID(simpleReq.Id);
            
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserReq userReq)
        {
            var res = userSvc.Register(userReq);
            return Ok(res);
        }
        [Authorize]
        [HttpPut("Update-User")]
        public IActionResult UpdateUser([FromBody] UserReq userReq)
        {
            var res = userSvc.UpdateUser(userReq);
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{Id:int}")]
        public IActionResult DeleteUser(int Id)
        {
            var res = userSvc.DeleteUser(Id);
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult LoginUser([FromBody] LoginReq loginReq)
        {
            var res = userSvc.LoginUser(loginReq);
            if (res != null)
            {
                UserModel userModel = new UserModel();
                User u = userSvc.All.SingleOrDefault(u => u.Username == loginReq.Username);
                string s = userSvc.userRep.userRoleRep.GetRole(u.UserId);
                userModel.Username = u.Username;
                userModel.Role = s;
                res.SetToken(_tokenService.CreateToken(userModel));
            }
            return Ok(res);
        }
    }
}
