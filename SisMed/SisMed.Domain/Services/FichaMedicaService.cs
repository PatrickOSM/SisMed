using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Repositories;
using SisMed.Domain.Interfaces.Services;

namespace SisMed.Domain.Services
{
    public class FichaMedicaService : ServiceBase<FichaMedica>, IFichaMedicaService
    {
        private readonly IFichaMedicaRepository _fichaMedicaRepository;

        public FichaMedicaService(IFichaMedicaRepository fichaMedicaRepository) : base(fichaMedicaRepository)
        {
            _fichaMedicaRepository = fichaMedicaRepository;
        }
    }
}
