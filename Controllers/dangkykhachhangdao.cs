using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMDT.Models;

namespace TMDT.Controllers
{
    public class dangkykhachhangdao
    {
        TMDTDAEntities db = null;

        public dangkykhachhangdao()
        {
            db = new TMDTDAEntities();
        }
        public long Insert(Account entity)
        {

            db.Accounts.Add(entity);
            db.SaveChanges();
            return entity.MaKH;


        }



        public bool CheckUserName(string TaiKhoang)
        {
            return db.Accounts.Count(x => x.TaiKhoan == TaiKhoang) > 0;
        }
        public bool checkgmail(string gmail)
        {
            return db.Accounts.Count(x => x.Email == gmail) > 0;
        }

    }
}