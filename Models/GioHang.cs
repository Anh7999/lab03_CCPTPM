using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDT.Models
{
    public class Giohang
    {
        TMDTDAEntities db = new TMDTDAEntities();

        public int idsp { set; get; }
        public string tensp { set; get; }
        public string anh { set; get; }
        public Double dongia { set; get; }
        public int soluong { set; get; }
        public Double thanhtien
        {
            get { return soluong * dongia; }

        }
        //Khoi tao gio hàng theo Masach duoc truyen vao voi Soluong mac dinh la 1
        public Giohang(int Masach)
        {
            idsp = Masach;
            SanPham sp = db.SanPhams.Single(n => n.IdSP == idsp);
            tensp = sp.TenSP;
            anh = sp.Images;
            dongia = double.Parse(sp.DonGia.ToString());
            soluong = 1;
        }
    }
}