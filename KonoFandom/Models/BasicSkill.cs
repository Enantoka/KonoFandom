using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
{
    public class BasicSkill : Skill
    {
        public ICollection<CardBasicSkill> CardBasicSkills { get; set; }
    }
}
