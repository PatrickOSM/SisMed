using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SisMed.Domain.Entities;

namespace SisMed.MVC.ViewModels
{
    public class FichaMedicaViewModel
    {
        [Key]
        public int FichaMedicaId { get; set; }

        [DisplayName("Data da Consulta")]
        [Required(ErrorMessage = "Preencha a Data da Consulta")]
        public DateTime DataConsulta { get; set; }

        [DisplayName("Exames Solicitados/á Solicitar")]
        [MaxLength(2000, ErrorMessage = "Máximo {1} caracteres")]
        public string ExamesSolicitados { get; set; }

        [DisplayName("Sintomas do Paciente")]
        [MaxLength(2000, ErrorMessage = "Máximo {1} caracteres")]
        public string SintomasPaciente { get; set; }

        [DisplayName("Medicamentos Receitados")]
        [MaxLength(2000, ErrorMessage = "Máximo {1} caracteres")]
        public string MedicamentosReceitados { get; set; }

        [DisplayName("Anotações Médicas")]
        [MaxLength(2000, ErrorMessage = "Máximo {1} caracteres")]
        public string AnotacoesMedicas { get; set; }

        [Required(ErrorMessage = "Preencha o campo Funcionário")]
        public int FuncionarioId { get; set; }

        public virtual FuncionarioViewModel Funcionario { get; set; }

        [DisplayName("Paciente")]
        [Required(ErrorMessage = "Preencha o campo Paciente")]
        public int PacienteId { get; set; }

        public virtual PacienteViewModel Paciente { get; set; }
    }
}