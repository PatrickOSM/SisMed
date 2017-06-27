using System.ComponentModel.DataAnnotations;

namespace SisMed.Infra.CrossCutting.Identity.Model
{
    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a nova senha")]
        [Compare("NewPassword", ErrorMessage = "A nova senha e a confirmação da nova senha são diferentes.")]
        public string ConfirmPassword { get; set; }
    }
}