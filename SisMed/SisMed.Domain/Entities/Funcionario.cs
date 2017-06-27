using System;
using System.Collections.Generic;

namespace SisMed.Domain.Entities
{
    public class Funcionario
    {
        public Funcionario()
        {
            Agendas = new List<Agenda>();
            FichasMedicas = new List<FichaMedica>();
        }

        public int FuncionarioId { get; set; }

        public string Nome { get; set; }

        public int SexoId { get; set; }

        public virtual Sexo Sexo { get; set; }

        public int CargoId { get; set; }

        public virtual Cargo Cargo { get; set; }

        public string Matricula { get; set; }

        public bool Ativo { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Rua { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public int CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }

        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }
        
        public virtual ICollection<Agenda> Agendas { get; set; }

        public virtual ICollection<FichaMedica> FichasMedicas { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
