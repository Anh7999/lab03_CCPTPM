using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMDT.Models
{
    public class RegisterModel
    {   [Key]
        public long id { set; get; }
        [Display(Name ="* tên đăng nhập")]
        [Required(ErrorMessage ="yêu cầu tên đăng nhập")]
        public string Ten { set; get; }

        [Display(Name = "* mật khẩu")]
        [StringLength(20,MinimumLength = 6, ErrorMessage ="độ dài mật khẩu ít nhất 6 ký tự.")]
        [Required(ErrorMessage = "yêu cầu Nhập mật khẩu")]
        public string Matkhau { set; get; }

        [Display(Name = "* xác nhận mật khẩu")]
        [Compare("Matkhau",ErrorMessage ="xác nhận mật khẩu khớp")]
        public string xacnhanMatkhau { set; get; }
        
        [Display(Name = "* Email")]
        [Required(ErrorMessage = "yêu cầu Nhập Email ")]
        public string Email { set; get; }
        [Display(Name = "* Họ")]
        public string Ho { set; get; }

        [Display(Name = "* Số diện thoại")]
        public int SDT { set; get; }
    

    }
}