using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Services;

namespace SisMed.Application
{
    public class FichaMedicaAppService : AppServiceBase<FichaMedica>, IFichaMedicaAppService
    {
        private readonly IFichaMedicaService _fichaMedicaService;

        public FichaMedicaAppService(IFichaMedicaService fichaMedicaService)
            : base(fichaMedicaService)
        {
            _fichaMedicaService = fichaMedicaService;
        }
    }
}
