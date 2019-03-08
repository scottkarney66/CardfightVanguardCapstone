namespace CardfightVanguardCapstone.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    public class LoginPO
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required with 8 to 20 characters.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Username is required with 8 to 20 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required with 8 to 20 characters.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password is required with 8 to 20 characters.")]
        public string Password { get; set; }


    }
}