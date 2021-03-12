using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AG04
{
    public class HeistSkillModel
    {
        public int SkillID { get; set; }
        public int HeistID { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int MembersNo { get; set; }
    }
}