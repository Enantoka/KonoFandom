using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.GameData.Models
{
    public class PassiveSkill : Skill
    {
        public ICollection<Card> Cards { get; set; }
    }
}
