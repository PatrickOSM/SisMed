using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Repositories;
using SisMed.Domain.Interfaces.Services;

namespace SisMed.Domain.Services
{
    public class SexoService : ServiceBase<Sexo>, ISexoService
    {
        private readonly ISexoRepository _sexoRepository;

        public SexoService(ISexoRepository sexoRepository) : base(sexoRepository)
        {
            _sexoRepository = sexoRepository;
        }
    }
}
