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
    
    public partial class C19_SubContractList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C19_SubContractList()
        {
            this.C20_StudentList = new HashSet<C20_StudentList>();
        }
    
        public int MaTP { get; set; }
        public string Tencongty { get; set; }
        public string TenViettat { get; set; }
        public string NganhNghe { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C20_StudentList> C20_StudentList { get; set; }
    }
}
