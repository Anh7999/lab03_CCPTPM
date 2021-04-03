using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMDT.Models;
namespace TMDT.Controllers
{
    public class KhachhangController : Controller
    {
        // GET: Khachhang
        DoAnTMDTEntities db = new DoAnTMDTEntities();



        [HttpGet]
        public ActionResult dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangky(RegisterModel model)
        {
            if (ModelState.IsValid)
            {

                var dao = new Usedao();
                if (dao.CheckUserName(model.Ten))
                {
                    ModelState.AddModelError("", "tên đăng nhập đã tồn tại");
                }
                else
                {
                    var use = new Account();
                    use.TenKH = model.Ten;
                    use.Matkhau = model.Matkhau;
               
                    

                    var result = dao.Insert(use);
                    if (result > 0 )
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