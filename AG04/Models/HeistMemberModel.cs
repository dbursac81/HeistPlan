using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AG04
{
    public class HeistMemberModel
    {
        public Nullable<int> MemberID { get; set; }
        public Nullable<int> HeistID { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }

        [StringLength(10, MinimumLength = 3, ErrorMessage = "Min 3 and max 10")]
        public string SkillLevel { get; set; }
    }
}