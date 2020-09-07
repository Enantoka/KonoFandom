using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
{
    public class Card
    {
        public int CardID { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1,5)]
        public int Rarity { get; set; }

        public string ImagePath { get; set; }

        public int CharacterID { get; set; }

        public Character Character { get; set; }

        public int? PassiveSkillID { get; set; }
        public PassiveSkill PassiveSkill { get; set; }
        public ICollection<CardBasicSkill> CardBasicSkills { get; set; }
        public ICollection<CardElement> CardElements { get; set; }

        // Stats attributes
        [Display(Name = "HP")]
        public int HealthPoints { get; set; }
        [Display(Name = "Physical Atk")]
        public int PhysicalAttack { get; set; }
        [Display(Name = "Magic Attack")]
        public int MagicAttack { get; set; }
        [Display(Name = "Physical Defense")]
        public int PhysicalDefense { get; set; }
        [Display(Name = "Magic Defense")]
        public int MagicDefense { get; set; }
        public int Agility { get; set; }
        public int Dexterity { get; set; }
        public int Luck { get; set; }

        // Elemental Resistances
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal FireResistance { get; set; }
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal WaterResistance { get; set; }
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal LightningResistance { get; set; }
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal EarthResistance { get; set; }
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal WindResistance { get; set; }
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal LightResistance { get; set; }
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal DarkResistance { get; set; }
    }
}
