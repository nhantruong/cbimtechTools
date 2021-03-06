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
    
    public partial class C24_IssueList
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> Year { get; set; }
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string IssueCode { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> FeedbackDate { get; set; }
        public string Descipline { get; set; }
        public string IssueStatus { get; set; }
        public Nullable<int> Revision { get; set; }
        public string Sources { get; set; }
        public string IssueDescription { get; set; }
        public int MemberID { get; set; }
        public Nullable<int> NoOfRepeat { get; set; }
        public string Level { get; set; }
        public string Tower { get; set; }
        public string Grid { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string SendTo { get; set; }
        public string Cc_to { get; set; }
        public string From { get; set; }
        public string Matrix1 { get; set; }
        public string Matrix2 { get; set; }
        public string Priority { get; set; }
        public string LayoutType { get; set; }
        public string Company_Team { get; set; }
        public string ErrorType { get; set; }
        public string BIMSolution { get; set; }
        public Nullable<System.DateTime> BIMSolution_Date { get; set; }
        public string ConstructorSolution { get; set; }
        public Nullable<System.DateTime> ConstructionSolution_Date { get; set; }
        public string ClientSolution { get; set; }
        public Nullable<System.DateTime> ClientSolution_Date { get; set; }
        public string ConsultantSolution { get; set; }
        public Nullable<System.DateTime> ConsultantSolution_Date { get; set; }
        public int isDone { get; set; }
        public string ClashType { get; set; }
        public string ClashScope { get; set; }
        public string CompanyLogo { get; set; }
        public string ConstructorLogo { get; set; }
        public string ClientLogo { get; set; }
        public string ConsultantLogo { get; set; }
    }
}
