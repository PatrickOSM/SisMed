using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SisMed.MVC.ViewModels
{
    public class TipoSanguineoViewModel
    {
        [Key]
        public int TipoSanguineoId { get; set; }

        [DisplayName("Tipo Sanguíneo")]
        [Required(ErrorMessage = "Preencha o tipo sanguíneo")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
    }
}