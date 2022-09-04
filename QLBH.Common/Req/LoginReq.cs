using System.ComponentModel.DataAnnotations;

namespace QLBH.Common.Req
{
    public class LoginReq
    {
        [Required(ErrorMessage = "Bạn phải nhập username")]
        public string Username { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập password")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}
