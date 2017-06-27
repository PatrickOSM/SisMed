using System.ComponentModel.DataAnnotations;

namespace SisMed.Infra.CrossCutting.Identity.Model
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Telefone")]
        public string Number { get; set; }
    }
}