namespace CardfightVanguardCapstone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    public class UserDO
    {
        public int UserID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string Firstname { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required with 8 to 20 characters.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Username is required with 8 to 20 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required with 8 to 20 characters.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password is required with 8 to 20 characters.")]
        public string Password { get; set; }
        //public string Role { get; set; }
        //public int Active { get; set; }
        //[Required(ErrorMessage = "Email is required.")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        //public string Email { get; set; }
        //public string Phone { get; set; }
        public int RoleID { get; set; }
    }
}