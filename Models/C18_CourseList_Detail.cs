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
    
    public partial class C18_CourseList_Detail
    {
        public int ID { get; set; }
        public int IDKhoaHoc { get; set; }
        public string TenKhoahoc { get; set; }
        public string Loaihinhdaotao { get; set; }
        public Nullable<double> SoluongHocvien { get; set; }
        public string CongtyThanhvien { get; set; }
        public string CongtyThauphu { get; set; }
        public string Congtruong { get; set; }
        public Nullable<int> PhongBan { get; set; }
        public Nullable<bool> Baitapcuoikhoa { get; set; }
        public Nullable<System.DateTime> NgayNopbaicuoikhoa { get; set; }
        public Nullable<double> DiemCuoiKhoa { get; set; }
        public string KetquaCaNhan { get; set; }
        public string AttachFile { get; set; }
        public Nullable<int> Diadiemhoctap { get; set; }
        public Nullable<int> MuctieuKhoahoc { get; set; }
        public Nullable<double> Thoigianhoc { get; set; }
        public string DVT { get; set; }
        public string CachthucHoctap { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> MaHV { get; set; }
        public string TenHocvien { get; set; }
    
        public virtual C07_CTCCompanyList C07_CTCCompanyList { get; set; }
        public virtual C12_SiteList C12_SiteList { get; set; }
        public virtual C17_CTCDepartment C17_CTCDepartment { get; set; }
        public virtual C20_StudentList C20_StudentList { get; set; }
        public virtual C23_Hinhthucdaotao C23_Hinhthucdaotao { get; set; }
        public virtual C29_MucTieuTraining C29_MucTieuTraining { get; set; }
    }
}
