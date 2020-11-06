using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
{
    public enum Weapon
    {
        Sword, Dagger, Rod, Staff, Spear
    }
    public class Character
    {
        public int CharacterID { get; set; }
        
        [StringLength(20)]
        public string Name { get; set; }

        public string Biography { get; set; }

        public string IconImagePath { get; set; }

        public string CharacterImagePath { get; set; }

        [Required]
        [EnumDataType(typeof(Weapon))]
        public Weapon Weapon { get; set; }

        public ICollection<Card> Cards { get; set; }

        public UltimateSkill UltimateSkill { get; set; }
    }
}
