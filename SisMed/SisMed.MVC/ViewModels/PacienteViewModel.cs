using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SisMed.MVC.ViewModels
{
    public class PacienteViewModel
    {
        [Key]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Nome { get; set; }

        [DisplayName("Sexo")]
        [Required(ErrorMessage = "Preencha o campo Sexo")]
        public int SexoId { get; set; }

        public virtual SexoViewModel Sexo { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(14, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(14, ErrorMessage = "Mínimo {1} caracteres")]
        public string Cpf { get; set; }

        [DisplayName("RG")]
        [Required(ErrorMessage = "Preencha o campo RG")]
        [MaxLength(10, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {1} caracteres")]
        public string Rg { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Preencha a data de nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Insira uma data válida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Nome da Mãe")]
        [Required(ErrorMessage = "Preencha o campo Nome da Mãe")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string NomeMae { get; set; }

        [DisplayName("Nome do Pai")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres")]
        public string NomePai { get; set; }

        [Required(ErrorMessage = "Preencha o campo Rua")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Rua { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "Preencha o campo CEP")]
        [MaxLength(10, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {1} caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Informe a Cidade")]
        public int CidadeId { get; set; }

        public virtual CidadeViewModel Cidade { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Informe o estado")]
        public int EstadoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(15, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Telefone { get; set; }

        [DisplayName("Telefone de Emergência")]
        [MaxLength(15, ErrorMessage = "Máximo {1} caracteres")]
        public string TelefoneEmergencia { get; set; }

        [DisplayName("Tipo Sanguíneo")]
        [Required(ErrorMessage = "Informe o Tipo Sanguíneo")]
        public int TipoSanguineoId { get; set; }

        public virtual TipoSanguineoViewModel TipoSanguineo { get; set; }

        [DisplayName("Possui Alergia?")]
        public bool Alergico { get; set; }

        [DisplayName("Alergias")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        public string Alergias { get; set; }

        [DisplayName("Possui Doenças Crônicas?")]
        public bool DoencaCronica { get; set; }

        [DisplayName("Doenças Crônicas")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        public string DoencasCronicas { get; set; }

        [DisplayName("Medicamentos de Uso Contínuo")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        public string MedicamentosContinuo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}