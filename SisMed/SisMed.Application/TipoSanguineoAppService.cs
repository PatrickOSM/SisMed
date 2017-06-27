using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Services;

namespace SisMed.Application
{
    public class TipoSanguineoAppService : AppServiceBase<TipoSanguineo>, ITipoSanguineoAppService
    {
        private readonly ITipoSanguineoService _tipoSanguineoService;

        public TipoSanguineoAppService(ITipoSanguineoService tipoSanguineoService)
            : base(tipoSanguineoService)
        {
            _tipoSanguineoService = tipoSanguineoService;
        }
    }
}
