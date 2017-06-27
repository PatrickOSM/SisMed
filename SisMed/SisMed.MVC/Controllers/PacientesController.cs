using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AutoMapper;
using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.MVC.ViewModels;
using SisMed.Util;
using SisMed.Util.Base;
using SisMed.Util.Enums;

namespace SisMed.MVC.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacienteAppService _pacienteApp;
        private readonly ISexoAppService _sexoApp;
        private readonly ICidadeAppService _cidadeApp;
        private readonly IEstadoAppService _estadoApp;
        private readonly ITipoSanguineoAppService _tipoSanguineoApp;

        public PacientesController(IPacienteAppService pacienteApp, ISexoAppService sexoApp, ICidadeAppService cidadeApp, IEstadoAppService estadoApp, ITipoSanguineoAppService tipoSanguineoApp)
        {
            _pacienteApp = pacienteApp;
            _sexoApp = sexoApp;
            _cidadeApp = cidadeApp;
            _estadoApp = estadoApp;
            _tipoSanguineoApp = tipoSanguineoApp;
        }

        // GET: Pacientes
        [Authorize]
        public ActionResult Index()
        {
            var pacienteViewModel = Mapper.Map<IEnumerable<Paciente>, IEnumerable<PacienteViewModel>>(_pacienteApp.GetAll());
            return View(pacienteViewModel);
        }

        // GET: Pacientes/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var paciente = _pacienteApp.GetById(id);
            var pacienteViewModel = Mapper.Map<Paciente, PacienteViewModel>(paciente);
            return View(pacienteViewModel);
        }

        // GET: Pacientes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.SexoId = new SelectList(_sexoApp.GetAll(), "SexoId", "Nome");
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome");
            ViewBag.TipoSanguineoId = new SelectList(_tipoSanguineoApp.GetAll(), "TipoSanguineoId", "Nome");

            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(PacienteViewModel paciente)
        {
            if (ModelState.IsValid)
            {
                var pacienteDomain = Mapper.Map<PacienteViewModel, Paciente>(paciente);
                _pacienteApp.Add(pacienteDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Paciente registrado com sucesso."), true);

                return RedirectToAction("Index");
            }

            ViewBag.SexoId = new SelectList(_pacienteApp.GetAll(), "SexoId", "Nome", paciente.SexoId);
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome");
            ViewBag.CidadeId = new SelectList(_cidadeApp.GetAll().Where(c => c.EstadoId == paciente.EstadoId), "CidadeId", "Nome", paciente.CidadeId);
            ViewBag.TipoSanguineoId = new SelectList(_pacienteApp.GetAll(), "TipoSanguineoId", "Nome", paciente.TipoSanguineoId);

            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));

            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var paciente = _pacienteApp.GetById(id);
            var pacienteViewModel = Mapper.Map<Paciente, PacienteViewModel>(paciente);

            //Preencher código do estado pela cidade da entidade
            pacienteViewModel.EstadoId = _cidadeApp.GetById(pacienteViewModel.CidadeId).EstadoId;

            ViewBag.SexoId = new SelectList(_sexoApp.GetAll(), "SexoId", "Nome", paciente.SexoId);
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome");
            ViewBag.CidadeId = new SelectList(_cidadeApp.GetAll().Where(c => c.EstadoId == pacienteViewModel.EstadoId), "CidadeId", "Nome", paciente.CidadeId);
            ViewBag.TipoSanguineoId = new SelectList(_tipoSanguineoApp.GetAll(), "TipoSanguineoId", "Nome", paciente.TipoSanguineoId);

            return View(pacienteViewModel);
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(PacienteViewModel paciente)
        {
            if (ModelState.IsValid)
            {
                var pacienteDomain = Mapper.Map<PacienteViewModel, Paciente>(paciente);
                _pacienteApp.Update(pacienteDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Paciente alterado com sucesso."), true);
                return RedirectToAction("Index");
            }

            ViewBag.SexoId = new SelectList(_sexoApp.GetAll(), "SexoId", "Nome", paciente.SexoId);
            ViewBag.CidadeId = new SelectList(_cidadeApp.GetAll(), "CidadeId", "Nome", paciente.CidadeId);
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome");
            ViewBag.TipoSanguineoId = new SelectList(_tipoSanguineoApp.GetAll(), "TipoSanguineoId", "Nome", paciente.TipoSanguineoId);

            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var paciente = _pacienteApp.GetById(id);
            var pacienteViewModel = Mapper.Map<Paciente, PacienteViewModel>(paciente);
            return View(pacienteViewModel);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var paciente = _pacienteApp.GetById(id);
            _pacienteApp.Remove(paciente);
            this.MostrarMensagem(new Toast(MessageType.success, "Paciente deletado com sucesso."), true);
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
