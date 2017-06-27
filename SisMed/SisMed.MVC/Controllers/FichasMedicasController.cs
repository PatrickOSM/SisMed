using System;
using AutoMapper;
using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SisMed.Util;
using SisMed.Util.Base;
using SisMed.Util.Enums;

namespace SisMed.MVC.Controllers
{
    public class FichasMedicasController : BaseController
    {
        private readonly IFichaMedicaAppService _fichaMedicaApp;
        private readonly IFuncionarioAppService _funcionarioApp;
        private readonly IPacienteAppService _pacienteApp;

        public FichasMedicasController(IFichaMedicaAppService fichaMedicaApp, IFuncionarioAppService funcionarioApp, IPacienteAppService pacienteApp)
        {
            _fichaMedicaApp = fichaMedicaApp;
            _funcionarioApp = funcionarioApp;
            _pacienteApp = pacienteApp;
        }

        // GET: Estados
        [Authorize]
        public ActionResult Index()
        {
            var fichaMedicaViewModel = Mapper.Map<IEnumerable<FichaMedica>, IEnumerable<FichaMedicaViewModel>>(_fichaMedicaApp.GetAll());
            return View(fichaMedicaViewModel);
        }

        // GET: Estados/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var fichaMedica = _fichaMedicaApp.GetById(id);
            var fichaMedicaViewModel = Mapper.Map<FichaMedica, FichaMedicaViewModel>(fichaMedica);
            return View(fichaMedicaViewModel);
        }

        // GET: Estados/Create
        [Authorize]
        public ActionResult Create()
        {
            //Coloca como data padrão o dia atual, mas pode ser alterado pelo usuário
            var fichaMedicaViewModel = new FichaMedicaViewModel
            {
                DataConsulta = DateTime.Today,
                //Inicializa o paciente vazio
                Paciente = new PacienteViewModel()
            };

            ViewBag.PacienteId = new SelectList(_pacienteApp.GetAll().OrderBy(p => p.Nome), "PacienteId", "Nome");

            return View(fichaMedicaViewModel);
        }

        // POST: Estados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(FichaMedicaViewModel fichaMedicaViewModel)
        {
            if (ModelState.IsValid)
            {
                var fichaMedica = Mapper.Map<FichaMedicaViewModel, FichaMedica>(fichaMedicaViewModel);
                _fichaMedicaApp.Add(fichaMedica);
                this.MostrarMensagem(new Toast(MessageType.success, "Ficha Médica registrada com sucesso."), true);
                return RedirectToAction("Index");
            }

            ViewBag.PacienteId = new SelectList(_pacienteApp.GetAll().OrderBy(p => p.Nome), "PacienteId", "Nome");

            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            return View(fichaMedicaViewModel);
        }

        // GET: Estados/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var fichaMedica = _fichaMedicaApp.GetById(id);
            var fichaMedicaViewModel = Mapper.Map<FichaMedica, FichaMedicaViewModel>(fichaMedica);

            ViewBag.PacienteId = new SelectList(_pacienteApp.GetAll().OrderBy(p => p.Nome), "PacienteId", "Nome");

            return View(fichaMedicaViewModel);
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

            ViewBag.PacienteId = new SelectList(_pacienteApp.GetAll().OrderBy(p => p.Nome), "PacienteId", "Nome");


            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            return View(funcionario);
        }

        // GET: Estados/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var fichaMedica = _fichaMedicaApp.GetById(id);
            var fichaMedicaViewModel = Mapper.Map<FichaMedica, FichaMedicaViewModel>(fichaMedica);
            return View(fichaMedicaViewModel);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var fichaMedica = _fichaMedicaApp.GetById(id);
            _fichaMedicaApp.Remove(fichaMedica);
            this.MostrarMensagem(new Toast(MessageType.success, "Ficha Médica deletada com sucesso."), true);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult InfoPaciente(int id)
        {
            var paciente = _pacienteApp.GetById(id);
            var pacienteViewModel = Mapper.Map<Paciente, PacienteViewModel>(paciente);
            return PartialView("PartialInfoPaciente", pacienteViewModel);
        }
    }
}
