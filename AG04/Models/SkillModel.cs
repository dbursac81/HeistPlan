using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AG04
{
    public class SkillModel
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public String Sex { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> ActiveInHeist { get; set; }

        public List<Skill> Skills { get; set; }
    }

    public class Skill
    {
        public int SkillID { get; set; }
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
    }
}