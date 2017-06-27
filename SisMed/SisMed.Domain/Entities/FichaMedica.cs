using System;

namespace SisMed.Domain.Entities
{
    public class FichaMedica
    {
        public int FichaMedicaId { get; set; }

        public DateTime DataConsulta { get; set; }

        public string ExamesSolicitados { get; set; }

        public string SintomasPaciente { get; set; }

        public string MedicamentosReceitados { get; set; }

        public string AnotacoesMedicas { get; set; }

        public int FuncionarioId { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        public int PacienteId { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
