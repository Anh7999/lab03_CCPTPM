//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TMDT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietThanhToan
    {
        public int IdDHH { get; set; }
        public int IdTT { get; set; }
        public Nullable<System.DateTime> NgayTT { get; set; }
        public Nullable<double> Tongtien { get; set; }
        public int Sdt { get; set; }
    
        public virtual DonDatHang DonDatHang { get; set; }
        public virtual ThanhToan ThanhToan { get; set; }
    }
}
