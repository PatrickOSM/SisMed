using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SisMed.MVC.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        public int EstadoId { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Preencha o campo Estado")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [DisplayName("UF")]
        [Required(ErrorMessage = "Preencha o campo UF")]
        [MaxLength(2, ErrorMessage = "Máximo {0} caracteres")]
        public string Sigla { get; set; }

        public virtual IEnumerable<CidadeViewModel> Cidades { get; set; }
    }
}