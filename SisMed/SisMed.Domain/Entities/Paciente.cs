using System;
using System.Collections.Generic;

namespace SisMed.Domain.Entities
{
    public class Paciente
    {
        public Paciente()
        {
            Agendas = new List<Agenda>();
        }
        public int PacienteId { get; set; }
        
        public string Nome { get; set; }

        public int SexoId { get; set; }

        public virtual Sexo Sexo { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public DateTime DataNascimento { get; set; }

        public string NomeMae { get; set; }

        public string NomePai { get; set; }

        public string Rua { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }        

        public int CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }

        public string Telefone { get; set; }

        public string TelefoneEmergencia { get; set; }

        public int TipoSanguineoId { get; set; }

        public virtual TipoSanguineo TipoSanguineo { get; set; }

        public bool Alergico { get; set; }

        public string Alergias { get; set; }

        public bool DoencaCronica { get; set; }

        public string DoencasCronicas { get; set; }

        public string MedicamentosContinuo { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Agenda> Agendas { get; set; }

        public virtual ICollection<FichaMedica> FichasMedicas { get; set; }
    }
}
