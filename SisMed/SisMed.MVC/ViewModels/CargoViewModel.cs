using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SisMed.MVC.ViewModels
{
    public class CargoViewModel
    {
        [Key]
        public int CargoId { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "Preencha o campo Cargo")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Descricao { get; set; }
    }
}