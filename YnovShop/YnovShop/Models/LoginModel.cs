using System;
using System.ComponentModel.DataAnnotations;

namespace YnovShop.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Veuillez indiquer votre adresse email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }
}
