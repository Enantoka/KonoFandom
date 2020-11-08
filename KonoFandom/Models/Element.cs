using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
{
    public class Element
    {
        [Display(Name = "ID")]
        public int ElementID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Image URL")]
        public string ImagePath { get; set; }
        public ICollection<CardElement> CardElements { get; set; }
    }
}
