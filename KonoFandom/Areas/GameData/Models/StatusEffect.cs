using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.GameData.Models
{
    public class StatusEffect : Effect
    {
        public ICollection<SkillStatusEffect> SkillStatusEffects { get; set; }
    }
}
