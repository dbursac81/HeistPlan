using System;
using System.Collections.Generic;
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
        public string SkillLevel { get; set; }
    }
}