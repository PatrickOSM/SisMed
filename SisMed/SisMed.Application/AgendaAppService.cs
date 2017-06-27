using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Services;

namespace SisMed.Application
{
    public class AgendaAppService : AppServiceBase<Agenda>, IAgendaAppService
    {
        private readonly IAgendaService _agendaService;

        public AgendaAppService(IAgendaService agendaService)
            : base(agendaService)
        {
            _agendaService = agendaService;
        }
    }
}
