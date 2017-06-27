using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Services;

namespace SisMed.Application
{
    public class CargoAppService : AppServiceBase<Cargo>, ICargoAppService
    {
        private readonly ICargoService _cargoService;

        public CargoAppService(ICargoService cargoService)
            : base(cargoService)
        {
            _cargoService = cargoService;
        }
    }
}
