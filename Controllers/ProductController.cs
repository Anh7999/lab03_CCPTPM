using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMDT.Models;

namespace TMDT.Controllers
{
    public class ProductController : Controller
    {
        TMDTDAEntities db = new TMDTDAEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product1(long id)
        {
            var v = from t in db.SanPhams
                    where t.IdLoaiSP == id && t.Hie == true
                    orderby t.Order ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}