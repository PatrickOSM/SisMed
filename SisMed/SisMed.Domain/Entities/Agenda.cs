using System;

namespace SisMed.Domain.Entities
{
    public class Agenda
    {
        public int AgendaId { get; set; }

        public string Titulo { get; set; }

        public DateTime DataInicio { get; set; }

        public int Duracao { get; set; }

        public int Status { get; set; }

        public int FuncionarioId { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        public int PacienteId { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
