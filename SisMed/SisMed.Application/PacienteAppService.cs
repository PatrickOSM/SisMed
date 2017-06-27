using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Services;

namespace SisMed.Application
{
    public class PacienteAppService : AppServiceBase<Paciente>, IPacienteAppService
    {
        private readonly IPacienteService _pacienteService;

        public PacienteAppService(IPacienteService pacienteService)
            : base(pacienteService)
        {
            _pacienteService = pacienteService;
        }
    }
}
