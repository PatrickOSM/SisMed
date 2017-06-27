using System.Collections.Generic;

namespace SisMed.Domain.Entities
{
    public class Estado
    {
        public int EstadoId { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public virtual IEnumerable<Cidade> Cidades { get; set; }
    }
}
