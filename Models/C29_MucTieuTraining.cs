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
    
    public partial class C29_MucTieuTraining
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C29_MucTieuTraining()
        {
            this.C18_CourseList_Detail = new HashSet<C18_CourseList_Detail>();
        }
    
        public int ID { get; set; }
        public string TenMucTieu { get; set; }
        public string GhiChu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C18_CourseList_Detail> C18_CourseList_Detail { get; set; }
    }
}
