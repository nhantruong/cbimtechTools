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
    
    public partial class C28_NTP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C28_NTP()
        {
            this.C30_NTP_ProjectDetails = new HashSet<C30_NTP_ProjectDetails>();
        }
    
        public int ID { get; set; }
        public string TenNTP { get; set; }
        public string Softname { get; set; }
        public Nullable<bool> Kientruc { get; set; }
        public Nullable<bool> KetCau { get; set; }
        public Nullable<bool> MEP { get; set; }
        public Nullable<bool> CanhQuan { get; set; }
        public Nullable<bool> NoiThat { get; set; }
        public Nullable<bool> PCCC { get; set; }
        public Nullable<bool> ThamTra { get; set; }
        public Nullable<bool> KhaoSat { get; set; }
        public Nullable<bool> DTM { get; set; }
        public Nullable<bool> DauNoiHaTang { get; set; }
        public Nullable<bool> MoHinh { get; set; }
        public Nullable<bool> Khac { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C30_NTP_ProjectDetails> C30_NTP_ProjectDetails { get; set; }
    }
}
