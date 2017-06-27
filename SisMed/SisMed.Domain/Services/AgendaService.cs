using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Repositories;
using SisMed.Domain.Interfaces.Services;

namespace SisMed.Domain.Services
{
    public class AgendaService : ServiceBase<Agenda>, IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository) : base(agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }
    }
}
