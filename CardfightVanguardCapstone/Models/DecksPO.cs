namespace CardfightVanguardCapstone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class DecksPO
    {
        [Display(Name = "Deck Name")]
        [Required(ErrorMessage = "Deck Name is required with 8 to 20 characters.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Deck Name is required with 8 to 20 characters.")]
        public string DeckName { get; set; }
    }
}