//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cbimtechTools.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class C46_QLThucTapCTC
    {
        public int UserID { get; set; }
        public string Dot { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public string Truong { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }
        public string NamSinh { get; set; }
        public string GioiTinh { get; set; }
        public string DienThoai { get; set; }
        public Nullable<double> KQHocTap { get; set; }
        public Nullable<double> DiemKienThuc { get; set; }
        public Nullable<double> DiemKyNang { get; set; }
        public Nullable<double> DiemThaiDo { get; set; }
        public Nullable<double> DiemKhuyenKhich { get; set; }
        public Nullable<double> DiemThucTap { get; set; }
        public Nullable<bool> KetThucThucTap { get; set; }
    
        public virtual C02_BIMstaff C02_BIMstaff { get; set; }
    }
}
