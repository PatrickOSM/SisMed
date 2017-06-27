using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SisMed.MVC.ViewModels
{
    public class CidadeViewModel
    {
        [Key]
        public int CidadeId { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [DisplayName("Estado")]
        public int EstadoId { get; set; }

        public virtual EstadoViewModel Estado { get; set; }
    }
}