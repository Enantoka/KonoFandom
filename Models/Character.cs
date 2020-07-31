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
        
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string FirstMidName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string LastName { get; set; }

        public string Biography { get; set; }

        [Required]
        public Weapon Weapon { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
