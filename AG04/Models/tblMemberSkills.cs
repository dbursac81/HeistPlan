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
    using System.ComponentModel.DataAnnotations;

    public partial class tblMemberSkills
    {
        public int SkillID { get; set; }
        public int MemberID { get; set; }
        public string Name { get; set; }

        [StringLength(10, MinimumLength = 1, ErrorMessage = "Min 1 and max 10")]
        public string SkillLevel { get; set; }
    
        public virtual tblMember tblMember { get; set; }
    }
}
