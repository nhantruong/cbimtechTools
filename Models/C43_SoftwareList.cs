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
    
    public partial class C43_SoftwareList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C43_SoftwareList()
        {
            this.C44_PCSoftwareReport = new HashSet<C44_PCSoftwareReport>();
        }
    
        public int ID { get; set; }
        public string Code { get; set; }
        public string Manufacture { get; set; }
        public string SoftwareName { get; set; }
        public string Detail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C44_PCSoftwareReport> C44_PCSoftwareReport { get; set; }
    }
}
