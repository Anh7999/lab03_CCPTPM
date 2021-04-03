using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using TMDT.Models;
namespace TMDT.Controllers
{
    public class Usedao
    {
        DoAnTMDTEntities db = null;

        public Usedao()
        {
            db = new DoAnTMDTEntities();
        }
        public long Insert(Account entity)
        {
           
                db.Accounts.Add(entity);
                db.SaveChanges();
                return entity.Sdt;


        }
               
              
    public bool CheckUserName(string tenKH)
        {
            return db.Accounts.Count(x => x.TenKH == tenKH) > 0;
        }
      
    }
}