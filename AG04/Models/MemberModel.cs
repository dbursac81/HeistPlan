using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AG04
{
    public class MemberModel
    {
        public int MemberID { get; set; }
        public string Name { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string Email { get; set; }
        public string Status { get; set; }
        public String Sex { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> ActiveInHeist { get; set; }

        public List<MemberSkill> Skills { get; set; }
    }

    public class MemberSkill
    {
        public int SkillID { get; set; }
        public int MemberID { get; set; }
        public string Name { get; set; }
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Min 1 and max 10")]
        public string Level { get; set; }
    }
}