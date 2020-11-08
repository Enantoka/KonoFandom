using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KonoFandom.Models
{
    public class Character
    {
        [Display(Name = "ID")]
        public int CharacterID { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public string Biography { get; set; }

        [Display(Name = "CV")]
        public string CharacterVoice { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM}")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Icon URL")]
        public string IconImagePath { get; set; }

        [Display(Name = "Image URL")]
        public string CharacterImagePath { get; set; }

        public ICollection<Card> Cards { get; set; }

        public UltimateSkill UltimateSkill { get; set; }
    }
}
