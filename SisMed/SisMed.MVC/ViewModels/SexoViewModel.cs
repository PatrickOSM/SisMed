using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SisMed.MVC.ViewModels
{
    public class SexoViewModel
    {
        [Key]
        public int SexoId { get; set; }

        [DisplayName("Sexo")]
        [Required(ErrorMessage = "Preencha o sexo")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
    }
}