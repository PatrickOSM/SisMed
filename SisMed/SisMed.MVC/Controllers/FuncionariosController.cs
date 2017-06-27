using AutoMapper;
using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using SisMed.Util;
using SisMed.Util.Base;
using SisMed.Util.Enums;

namespace SisMed.MVC.Controllers
{
    public class FuncionariosController : BaseController
    {
        private readonly IFuncionarioAppService _funcionarioApp;
        private readonly ISexoAppService _sexoApp;
        private readonly ICidadeAppService _cidadeApp;
        private readonly IEstadoAppService _estadoApp;
        private readonly ICargoAppService _cargoApp;

        public FuncionariosController(IFuncionarioAppService funcionarioApp, ISexoAppService sexoApp, ICidadeAppService cidadeApp, IEstadoAppService estadoApp, ICargoAppService cargoApp)
        {
            _funcionarioApp = funcionarioApp;
            _sexoApp = sexoApp;
            _cidadeApp = cidadeApp;
            _estadoApp = estadoApp;
            _cargoApp = cargoApp;
        }

        // GET: Estados
        [Authorize]
        public ActionResult Index()
        {
            var funcionarioViewModel = Mapper.Map<IEnumerable<Funcionario>, IEnumerable<FuncionarioViewModel>>(_funcionarioApp.GetAll());
            return View(funcionarioViewModel);
        }

        // GET: Estados/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var funcionario = _funcionarioApp.GetById(id);
            var funcionarioViewModel = Mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);
            return View(funcionarioViewModel);
        }

        // GET: Estados/Create
        [Authorize]
        public ActionResult Create()
        {
            FuncionarioViewModel funcionarioViewModel = new FuncionarioViewModel();
            ViewBag.SexoId = new SelectList(_sexoApp.GetAll(), "SexoId", "Nome");
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome");
            ViewBag.CargoId = new SelectList(_cargoApp.GetAll(), "CargoId", "Nome");

            return View(funcionarioViewModel);
        }

        // POST: Estados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(FuncionarioViewModel funcionario)
        {
            if (ModelState.IsValid)
            {
                var funcionarioDomain = Mapper.Map<FuncionarioViewModel, Funcionario>(funcionario);
                _funcionarioApp.Add(funcionarioDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Funcionário registrado com sucesso."), true);
                return RedirectToAction("Index");
            }

            ViewBag.SexoId = new SelectList(_sexoApp.GetAll(), "SexoId", "Nome", funcionario.SexoId);
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome");
            ViewBag.CidadeId = new SelectList(_cidadeApp.GetAll().Where(c => c.EstadoId == funcionario.EstadoId), "CidadeId", "Nome", funcionario.CidadeId);
            ViewBag.CargoId = new SelectList(_cargoApp.GetAll(), "CargoId", "Nome", funcionario.CargoId);

            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            return View(funcionario);
        }

        // GET: Estados/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var funcionario = _funcionarioApp.GetById(id);
            var funcionarioViewModel = Mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);

            //Preencher código do estado pela cidade da entidade
            funcionarioViewModel.EstadoId = _cidadeApp.GetById(funcionarioViewModel.CidadeId).EstadoId;

            ViewBag.SexoId = new SelectList(_sexoApp.GetAll(), "SexoId", "Nome", funcionario.SexoId);
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome");
            ViewBag.CidadeId = new SelectList(_cidadeApp.GetAll().Where(c => c.EstadoId == funcionarioViewModel.EstadoId), "CidadeId", "Nome", funcionario.CidadeId);
            ViewBag.CargoId = new SelectList(_cargoApp.GetAll(), "CargoId", "Nome", funcionario.CargoId);

            return View(funcionarioViewModel);
        }

        // POST: Estados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(FuncionarioViewModel funcionario)
        {
            if (ModelState.IsValid)
            {
                var funcionarioDomain = Mapper.Map<FuncionarioViewModel, Funcionario>(funcionario);
                _funcionarioApp.Update(funcionarioDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Funcionário alterado com sucesso."), true);
                return RedirectToAction("Index");
            }

            ViewBag.SexoId = new SelectList(_sexoApp.GetAll(), "SexoId", "Nome", funcionario.SexoId);
            ViewBag.CidadeId = new SelectList(_cidadeApp.GetAll(), "CidadeId", "Nome", funcionario.CidadeId);
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome");
            ViewBag.CargoId = new SelectList(_cargoApp.GetAll(), "CargoId", "Nome", funcionario.CargoId);


            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            return View(funcionario);
        }

        // GET: Estados/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var funcionario = _funcionarioApp.GetById(id);
            var funcionarioViewModel = Mapper.Map<Funcionario, FuncionarioViewModel>(funcionario);
            return View(funcionarioViewModel);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var funcionario = _funcionarioApp.GetById(id);
            _funcionarioApp.Remove(funcionario);
            this.MostrarMensagem(new Toast(MessageType.success, "Funcionário deletado com sucesso."), true);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Retorna uma lista de cidades baseada no id do estado enviado como parâmetro
        /// </summary>
        /// <param name="estadoId">ID do estado</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult ListarCidades(int estadoId)
        {
            var listaCidades = _cidadeApp.GetAll().Where(c => c.EstadoId == estadoId).ToList();
            string resultado = new JavaScriptSerializer().Serialize(listaCidades);//Serializa lista para retornar a requisição

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }
    }
}
