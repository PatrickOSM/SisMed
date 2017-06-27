using AutoMapper;
using SisMed.Domain.Entities;
using SisMed.MVC.ViewModels;

namespace SisMed.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<Cargo, CargoViewModel > ();
            CreateMap<Cidade, CidadeViewModel>();
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<Funcionario, FuncionarioViewModel>();
            CreateMap<Paciente, PacienteViewModel>();
            CreateMap<Sexo, SexoViewModel>();
            CreateMap<TipoSanguineo, TipoSanguineoViewModel>();
        }
    }
}