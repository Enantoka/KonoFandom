using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.GameData.Models
{
    public class CardBasicSkill
    {
        public int CardID { get; set; }
        public Card Card { get; set; }
        public int BasicSkillID { get; set; }
        public BasicSkill BasicSkill { get; set; }
    }
}
