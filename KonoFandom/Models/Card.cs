using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KonoFandom.Models
{
    public enum Weapon
    {
        Sword, Dagger, Rod, Staff, Spear
    }

    public class Card
    {
        [Display(Name = "ID")]
        public int CardID { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1,5)]
        public int Rarity { get; set; }

        [Required]
        [EnumDataType(typeof(Weapon))]
        public Weapon Weapon { get; set; }

        [Display(Name = "Image URL")]
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
        [Display(Name = "P. Atk")]
        public int PhysicalAttack { get; set; }
        [Display(Name = "M. Atk")]
        public int MagicAttack { get; set; }
        [Display(Name = "P. Def")]
        public int PhysicalDefense { get; set; }
        [Display(Name = "M. Def")]
        public int MagicDefense { get; set; }
        [Display(Name = "Agi")]
        public int Agility { get; set; }
        [Display(Name = "Dex")]
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
