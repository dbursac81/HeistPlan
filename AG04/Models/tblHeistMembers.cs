//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AG04.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblHeistMembers
    {
        public int ID { get; set; }
        public Nullable<int> HeistID { get; set; }
        public Nullable<int> MemberID { get; set; }
        public Nullable<bool> ActiveInHeist { get; set; }
        public string Status { get; set; }
    
        public virtual tblHeist tblHeist { get; set; }
        public virtual tblMember tblMember { get; set; }
    }
}
