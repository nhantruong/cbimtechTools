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
    
    public partial class C15_TimeSheet
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public string ProjectID { get; set; }
        public string MemberName { get; set; }
        public System.DateTime RecordDate { get; set; }
        public string ProjectName { get; set; }
        public string WorkType { get; set; }
        public Nullable<int> WorkGroup { get; set; }
        public int Hour { get; set; }
        public int OvertimeHour { get; set; }
        public string Description { get; set; }
    
        public virtual C01_DesignProject C01_DesignProject { get; set; }
        public virtual C02_BIMstaff C02_BIMstaff { get; set; }
        public virtual C16a_WorkTypeGroup C16a_WorkTypeGroup { get; set; }
    }
}
