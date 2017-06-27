using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Services;

namespace SisMed.Application
{
    public class SexoAppService : AppServiceBase<Sexo>, ISexoAppService
    {
        private readonly ISexoService _sexoService;

        public SexoAppService(ISexoService sexoService)
            : base(sexoService)
        {
            _sexoService = sexoService;
        }
    }
}
