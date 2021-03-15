using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AG04
{
    public class HeistSkillModel
    {
        public int SkillID { get; set; }
        public int HeistID { get; set; }
        public string Name { get; set; }
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Min 3 and max 10")]
        public string Level { get; set; }
        [Range(3, Int32.MaxValue, ErrorMessage = "Min 3 members") ]
        public int MembersNo { get; set; }
    }
}