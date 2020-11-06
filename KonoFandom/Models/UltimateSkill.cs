using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
{
    public class UltimateSkill : Skill
    {
        public int CharacterID { get; set; }
        public Character Character { get; set; }
    }
}
