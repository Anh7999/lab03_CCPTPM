using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TMDT.Models

{
    public class RegisterModel
    {
        [Key]
        public long MaKH { set; get; }
        [Display(Name = "* tên đăng nhập")]
        [Required(ErrorMessage = "yêu cầu tên đăng nhập")]
        public string TaiKhoan { set; get; }

        [Display(Name = "* mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "độ dài mật khẩu ít nhất 6 ký tự.")]
        [Required(ErrorMessage = "yêu cầu Nhập mật khẩu")]
        public string Matkhau { set; get; }

        [Display(Name = "* xác nhận mật khẩu")]
        [Compare("Matkhau", ErrorMessage = "xác nhận mật khẩu khớp")]
        public string xacnhanMatkhau { set; get; }

        [Display(Name = "* Email")]
        [Required(ErrorMessage = "yêu cầu Nhập Email ")]
        [RegularExpression(@"^[-a-z0-9~!$%^&*_=+}{\'?]+(\.[-a-z0-9~!$%^&*_=+}{\'?]+)*@([a-z0-9_][-a-z0-9_]*(\.[-a-z0-9_]+)*\.(aero|arpa|biz|com|coop|edu|gov|info|int|mil|museum|name|net|org|pro|travel|mobi|[a-z][a-z])|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,5})?$", ErrorMessage = "Vui lòng nhập Email hợp lệ")]
        public string Email { set; get; }
        [Display(Name = "* Ten")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Vui lòng nhập Tên hợp lệ")]
        public string TenKH { set; get; }

        [Display(Name = "* Số diện thoại")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "it nhat 10 nhiu nhat 12.")]

       
        public string SDT { set; get; }
    }
}