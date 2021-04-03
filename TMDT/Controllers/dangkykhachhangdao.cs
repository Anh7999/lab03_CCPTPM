using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMDT.Models;

namespace TMDT.Controllers
{
    public class dangkykhachhangdao
    {


        DoAnTMDTEntities db = null;

        public dangkykhachhangdao()
        {
            db = new DoAnTMDTEntities();
        }
        public long Insert(taikhoangkhachhang entity)
        {

            db.taikhoangkhachhangs.Add(entity);
            db.SaveChanges();
            return entity.id;


        }


     
        public bool CheckUserName(string tennn)
        {
            return db.taikhoangkhachhangs.Count(x => x.Ten == tennn) > 0;
        }
        public bool checkgmail(string gmail)
        {
            return db.taikhoangkhachhangs.Count(x => x.Email == gmail) > 0;
        }

    }
}
