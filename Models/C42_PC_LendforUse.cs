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
    
    public partial class C42_PC_LendforUse
    {
        public int ID { get; set; }
        public string NguoiMuon { get; set; }
        public string LyDo { get; set; }
        public string PhongBan { get; set; }
        public string SoHieuMayTinh { get; set; }
        public int XacNhanMuon { get; set; }
        public Nullable<System.DateTime> NgayMuon { get; set; }
        public Nullable<System.DateTime> NgayTra { get; set; }
        public string Before_HoatDong { get; set; }
        public Nullable<int> Before_Chuot { get; set; }
        public Nullable<int> Before_Nguon { get; set; }
        public Nullable<int> Before_BagCover { get; set; }
        public Nullable<int> After_HoatDong { get; set; }
        public Nullable<int> After_Chuot { get; set; }
        public Nullable<int> After_Nguon { get; set; }
        public Nullable<int> After_BagCover { get; set; }
        public Nullable<int> IsFree { get; set; }
    
        public virtual C40_PC_List C40_PC_List { get; set; }
    }
}
