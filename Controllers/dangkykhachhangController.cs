using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMDT.Models;
namespace TMDT.Controllers
{
    public class dangkykhachhangController : Controller
    {
        TMDTDAEntities db = new TMDTDAEntities();
        // GET: dangkykhachhang
        [HttpGet]
        public ActionResult dangkykhachhang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangkykhachhang(RegisterModel model)
        {
            if (ModelState.IsValid)
            {

                var dao = new dangkykhachhangdao();
                if (dao.CheckUserName(model.TaiKhoan))
                {
                    ModelState.AddModelError("", "tên đăng nhập đã tồn tại");
                }
                if (dao.CheckUserName(model.Email))
                {
                    ModelState.AddModelError("", "email đăng nhập đã tồn tại");
                }
                else
                {
                    var taikhoangkhachhang = new Account();
                    taikhoangkhachhang.TaiKhoan = model.TaiKhoan;
                    taikhoangkhachhang.Matkhau = model.Matkhau;
                    taikhoangkhachhang.Email = model.Email;
                    taikhoangkhachhang.Sdt = model.SDT;
                    taikhoangkhachhang.TenKH = model.TenKH;
                    


                    var result = dao.Insert(taikhoangkhachhang);
                    if (result > 0)
                    {
                        ViewBag.Success = "đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "đăng ký không thành công");
                    }

                }

            }
            return View(model);
        }
    }
}