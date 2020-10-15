using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class SkillsLevel
    {
        public int SkillId { get; set; }
        public string SkillLevel { get; set; }
        public int? BadgeId { get; set; }

        public int? PathId { get; set; }
    }
}
