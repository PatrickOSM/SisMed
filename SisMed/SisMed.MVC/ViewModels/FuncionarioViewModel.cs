using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SisMed.MVC.ViewModels
{
    public class FuncionarioViewModel
    {
        [Key]
        public int FuncionarioId { get; set; }
        
        [Required(ErrorMessage = "Preencha o nome")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Nome { get; set; }

        [DisplayName("Sexo")]
        [Required(ErrorMessage = "Informe o sexo")]
        public int SexoId { get; set; }

        public virtual SexoViewModel Sexo { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "Informe o cargo")]
        public int CargoId { get; set; }

        public virtual CargoViewModel Cargo { get; set; }

        [DisplayName("Matrícula")]
        [Required(ErrorMessage = "Preencha a matrícula")]
        [MaxLength(10, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {1} caracteres")]
        public string Matricula { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [DisplayName("E-Mail")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        public string Email { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "Preencha o CPF")]
        [MaxLength(14, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(14, ErrorMessage = "Mínimo {1} caracteres")]
        public string Cpf { get; set; }

        [DisplayName("RG")]
        [Required(ErrorMessage = "Preencha o RG")]
        [MaxLength(10, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {1} caracteres")]
        public string Rg { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Preencha a data de nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Insira uma data válida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha a rua")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Rua { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "Preencha o CEP")]
        [MaxLength(10, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {1} caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Preencha o bairro")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Informe a cidade")]
        public int CidadeId { get; set; }

        public CidadeViewModel Cidade { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Informe o estado")]
        public int EstadoId { get; set; }

        [Required(ErrorMessage = "Preencha o telefone")]
        [MaxLength(15, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [Phone(ErrorMessage = "Preencha um telefone válido")]
        public string Telefone { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
    }
}