using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AG04
{
    public class HeistModel
    {
        public int HeistID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> StartDate { get; set; }

        [Display(Name = "Start time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> StartTime { get; set; }

        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> EndDate { get; set; }

        [Display(Name = "End time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> EndTime { get; set; }

        public string Status { get; set; }
        public bool Active { get; set; }

        public int SkillsID { get; set; }      
        public string SkillLevel { get; set; }
        public Nullable<short> MembersNo { get; set; }

        public List<HeistSkillModel> HeistSkills { get; set; }

        public List<HeistMemberModel> HeistMembers { get; set; }
    }  
}