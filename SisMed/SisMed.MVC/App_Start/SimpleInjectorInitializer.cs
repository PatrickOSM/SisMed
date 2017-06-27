using System.Reflection;
using System.Web;
using System.Web.Mvc;
using SisMed.Infra.CrossCutting.IoC;
using Microsoft.Owin;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SisMed.Application;
using SisMed.Application.Interface;
using SisMed.Domain.Interfaces.Repositories;
using SisMed.Domain.Interfaces.Services;
using SisMed.Domain.Services;
using SisMed.Infra.Data.Repositories;
using SisMed.MVC;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace SisMed.MVC
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Chamada dos módulos do Simple Injector
            InitializeContainer(container);

            // Necessário para registrar o ambiente do Owin que é dependência do Identity
            // Feito fora da camada de IoC para não levar o System.Web para fora
            container.RegisterPerWebRequest(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying())
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;

            });
            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            container.Register<ICargoAppService, CargoAppService>(Lifestyle.Scoped);
            container.Register<ICidadeAppService, CidadeAppService>(Lifestyle.Scoped);
            container.Register<IEstadoAppService, EstadoAppService>(Lifestyle.Scoped);
            container.Register<IFuncionarioAppService, FuncionarioAppService>(Lifestyle.Scoped);
            container.Register<IPacienteAppService, PacienteAppService>(Lifestyle.Scoped);
            container.Register<ISexoAppService, SexoAppService>(Lifestyle.Scoped);
            container.Register<ITipoSanguineoAppService, TipoSanguineoAppService>(Lifestyle.Scoped);
            container.Register<IFichaMedicaAppService, FichaMedicaAppService>(Lifestyle.Scoped);

            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.Register<ICargoService, CargoService>(Lifestyle.Scoped);
            container.Register<ICidadeService, CidadeService>(Lifestyle.Scoped);
            container.Register<IEstadoService, EstadoService>(Lifestyle.Scoped);
            container.Register<IFuncionarioService, FuncionarioService>(Lifestyle.Scoped);
            container.Register<IPacienteService, PacienteService>(Lifestyle.Scoped);
            container.Register<ISexoService, SexoService>(Lifestyle.Scoped);
            container.Register<ITipoSanguineoService, TipoSanguineoService>(Lifestyle.Scoped);
            container.Register<IFichaMedicaService, FichaMedicaService>(Lifestyle.Scoped);

            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            container.Register<ICargoRepository, CargoRepository>(Lifestyle.Scoped);
            container.Register<ICidadeRepository, CidadeRepository>(Lifestyle.Scoped);
            container.Register<IEstadoRepository, EstadoRepository>(Lifestyle.Scoped);
            container.Register<IFuncionarioRepository, FuncionarioRepository>(Lifestyle.Scoped);
            container.Register<IPacienteRepository, PacienteRepository>(Lifestyle.Scoped);
            container.Register<ISexoRepository, SexoRepository>(Lifestyle.Scoped);
            container.Register<ITipoSanguineoRepository, TipoSanguineoRepository>(Lifestyle.Scoped);
            container.Register<IFichaMedicaRepository, FichaMedicaRepository>(Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}