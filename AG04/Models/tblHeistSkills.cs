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

    public partial class tblHeistSkills
    {
        public int SkillsID { get; set; }
        public int HeistID { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter skill level")]
        public string SkillLevel { get; set; }
        [Required(ErrorMessage = "Please enter number of members")]
        public Nullable<short> MembersNo { get; set; }
    
        public virtual tblHeist tblHeist { get; set; }
    }
}
