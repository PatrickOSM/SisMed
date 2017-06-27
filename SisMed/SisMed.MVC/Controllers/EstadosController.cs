using AutoMapper;
using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using SisMed.Util;
using SisMed.Util.Base;
using SisMed.Util.Enums;

namespace SisMed.MVC.Controllers
{
    public class EstadosController : BaseController
    {
        private readonly IEstadoAppService _estadoApp;

        public EstadosController(IEstadoAppService estadoApp)
        {
            _estadoApp = estadoApp;
        }

        // GET: Estados
        [Authorize]
        public ActionResult Index()
        {
            var estadoViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoApp.GetAll());
            return View(estadoViewModel);
        }

        // GET: Estados/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var estado = _estadoApp.GetById(id);
            var estadoViewModel = Mapper.Map<Estado, EstadoViewModel>(estado);
            return View(estadoViewModel);
        }

        // GET: Estados/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(EstadoViewModel estado)
        {
            if (ModelState.IsValid)
            {
                var estadoDomain = Mapper.Map<EstadoViewModel, Estado>(estado);
                _estadoApp.Add(estadoDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Estado registrado com sucesso."), true);
                return RedirectToAction("Index");
            }
            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            return View(estado);
        }

        // GET: Estados/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var estado = _estadoApp.GetById(id);
            var estadoViewModel = Mapper.Map<Estado, EstadoViewModel>(estado);
            return View(estadoViewModel);
        }

        // POST: Estados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(EstadoViewModel estado)
        {
            if (ModelState.IsValid)
            {
                var estadoDomain = Mapper.Map<EstadoViewModel, Estado>(estado);
                _estadoApp.Update(estadoDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Estado alterado com sucesso."), true);
                return RedirectToAction("Index");
            }
            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            return View(estado);
        }

        // GET: Estados/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var estado = _estadoApp.GetById(id);
            var estadoViewModel = Mapper.Map<Estado, EstadoViewModel>(estado);
            return View(estadoViewModel);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var estado = _estadoApp.GetById(id);
            _estadoApp.Remove(estado);
            this.MostrarMensagem(new Toast(MessageType.success, "Estado deletado com sucesso."), true);
            return RedirectToAction("Index");
        }
    }
}
