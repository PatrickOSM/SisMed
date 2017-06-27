using AutoMapper;
using SisMed.Domain.Entities;
using SisMed.MVC.ViewModels;

namespace SisMed.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<CargoViewModel, Cargo>();
            CreateMap<CidadeViewModel, Cidade>();
            CreateMap<EstadoViewModel, Estado>();
            CreateMap<FuncionarioViewModel, Funcionario>();
            CreateMap<PacienteViewModel, Paciente>();
            CreateMap<SexoViewModel, Sexo>();
            CreateMap<TipoSanguineoViewModel, TipoSanguineo>();
        }
    }
}