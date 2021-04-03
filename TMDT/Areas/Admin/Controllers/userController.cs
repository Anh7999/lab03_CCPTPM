using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMDT.Models;

namespace TMDT.Areas.Admin.Controllers
{
    public class userController : Controller
    {
        DoAnTMDTEntities db = new DoAnTMDTEntities();
        // GET: Admin/user
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)

        {

            user user = db.users.SingleOrDefault(x => x.username == username && x.password == password);
            if (user != null)
            {
                Session["id"] = user.id;
                Session["username"] = user.username;
                return RedirectToAction("Index");
            }
            ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu!";
            return View();
        }
    }
}
