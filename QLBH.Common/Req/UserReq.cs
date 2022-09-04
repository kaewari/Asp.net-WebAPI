using System.ComponentModel.DataAnnotations;

namespace QLBH.Common.Req
{
    public class UserReq
    {
        [Required(ErrorMessage = "Bạn phải nhập Id")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập fullname")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập password")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu xác nhận")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { set; get; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }       
    }
}
