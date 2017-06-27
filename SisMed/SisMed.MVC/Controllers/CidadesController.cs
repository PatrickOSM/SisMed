using AutoMapper;
using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SisMed.Util;
using SisMed.Util.Base;
using SisMed.Util.Enums;

namespace SisMed.MVC.Controllers
{
    public class CidadesController : BaseController
    {
        private readonly ICidadeAppService _cidadeApp;
        private readonly IEstadoAppService _estadoApp;

        public CidadesController(ICidadeAppService cidadeApp, IEstadoAppService estadoApp)
        {
            _cidadeApp = cidadeApp;
            _estadoApp = estadoApp;
        }

        // GET: Cidades
        [Authorize]
        public ActionResult Index()
        {
            var cidadeViewModel = Mapper.Map<IEnumerable<Cidade>, IEnumerable<CidadeViewModel>>(_cidadeApp.GetAll());
            return View(cidadeViewModel);
        }

        // GET: Cidades/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var cidade = _cidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);
            return View(cidadeViewModel);
        }

        // GET: Cidades/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll().OrderBy(e => e.Nome), "EstadoId", "Nome");
            return View();
        }

        // POST: Cidades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CidadeViewModel cidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                var cidadeDomain = Mapper.Map<CidadeViewModel, Cidade>(cidadeViewModel);
                _cidadeApp.Add(cidadeDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Cidade registrada com sucesso."), true);
                return RedirectToAction("Index");
            }

            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll(), "EstadoId", "Nome", cidadeViewModel.EstadoId);
            return View(cidadeViewModel);
        }

        // GET: Cidades/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var cidade = _cidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll(), "EstadoId", "Nome", cidadeViewModel.EstadoId);

            return View(cidadeViewModel);
        }

        // POST: Cidades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(CidadeViewModel cidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                var cidadeDomain = Mapper.Map<CidadeViewModel, Cidade>(cidadeViewModel);
                _cidadeApp.Update(cidadeDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Cidade alterada com sucesso."), true);
                return RedirectToAction("Index");
            }

            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            ViewBag.EstadoId = new SelectList(_estadoApp.GetAll(), "EstadoId", "Nome", cidadeViewModel.EstadoId);
            return View(cidadeViewModel);
        }

        // GET: Cidades/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var cidade = _cidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return View(cidadeViewModel);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var cidade = _cidadeApp.GetById(id);
            _cidadeApp.Remove(cidade);
            this.MostrarMensagem(new Toast(MessageType.success, "Cidade deletada com sucesso."), true);
            return RedirectToAction("Index");
        }
    }
}
