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
    
    public partial class C34_SoftwareSkill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C34_SoftwareSkill()
        {
            this.C02a_MemberSkills = new HashSet<C02a_MemberSkills>();
        }
    
        public int Id { get; set; }
        public string SoftwareSkillName { get; set; }
        public string SoftwareType { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C02a_MemberSkills> C02a_MemberSkills { get; set; }
    }
}