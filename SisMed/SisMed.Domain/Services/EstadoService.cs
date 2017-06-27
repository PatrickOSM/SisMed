using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Repositories;
using SisMed.Domain.Interfaces.Services;

namespace SisMed.Domain.Services
{
    public class EstadoService : ServiceBase<Estado>, IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IEstadoRepository estadoRepository) : base(estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }
    }
}
