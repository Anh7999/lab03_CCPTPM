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
        DoAnTMDTEntities db = new DoAnTMDTEntities();
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
                if (dao.CheckUserName(model.Ten))
                {
                    ModelState.AddModelError("", "tên đăng nhập đã tồn tại");
                }
                if (dao.CheckUserName(model.Email))
                {
                    ModelState.AddModelError("", "email đăng nhập đã tồn tại");
                }
                else
                {
                    var taikhoangkhachhang = new taikhoangkhachhang();
                    taikhoangkhachhang.Ten = model.Ten;
                    taikhoangkhachhang.Matkhau = model.Matkhau;
                    taikhoangkhachhang.Email = model.Email;
                    taikhoangkhachhang.SDT = model.SDT;
                    taikhoangkhachhang.Ho = model.Ho;
                    taikhoangkhachhang.HienThi = true;


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