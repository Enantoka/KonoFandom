using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.GameData.Models
{
    public abstract class Skill
    {
        public int SkillID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public int? BuffEffectID { get; set; }
        public BuffEffect BuffEffect { get; set; }
        public int? DebuffEffectID { get; set; }
        public DebuffEffect DebuffEffect { get; set; }
        public ICollection<SkillStatusEffect> SkillStatusEffects { get; set; }
    }
}
