using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Repositories;
using SisMed.Domain.Interfaces.Services;

namespace SisMed.Domain.Services
{
    public class TipoSanguineoService : ServiceBase<TipoSanguineo>, ITipoSanguineoService
    {
        private readonly ITipoSanguineoRepository _tipoSanguineoRepository;

        public TipoSanguineoService(ITipoSanguineoRepository tipoSanguineoRepository) : base(tipoSanguineoRepository)
        {
            _tipoSanguineoRepository = tipoSanguineoRepository;
        }
    }
}
