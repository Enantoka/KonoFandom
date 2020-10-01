using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.GameData.Models
{
    public class SkillStatusEffect
    {
        public int SkillID { get; set; }
        public Skill Skill { get; set; }
        public int StatusEffectID { get; set; }
        public StatusEffect StatusEffect { get; set; }
    }
}
