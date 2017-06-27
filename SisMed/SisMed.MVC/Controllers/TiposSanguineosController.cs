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
    public class TiposSanguineosController : BaseController
    {
        private readonly ITipoSanguineoAppService _tipoSanguineoApp;

        public TiposSanguineosController(ITipoSanguineoAppService tipoSanguineoApp)
        {
            _tipoSanguineoApp = tipoSanguineoApp;
        }

        // GET: TipoSanguineo
        [Authorize]
        public ActionResult Index()
        {
            var tipoSanguineoViewModel = Mapper.Map<IEnumerable<TipoSanguineo>, IEnumerable<TipoSanguineoViewModel>>(_tipoSanguineoApp.GetAll());
            return View(tipoSanguineoViewModel);
        }

        // GET: TipoSanguineo/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var tipoSanguineo = _tipoSanguineoApp.GetById(id);
            var tipoSanguineoViewModel = Mapper.Map<TipoSanguineo, TipoSanguineoViewModel>(tipoSanguineo);
            return View(tipoSanguineoViewModel);
        }

        // GET: TipoSanguineo/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoSanguineo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(TipoSanguineoViewModel tipoSanguineo)
        {
            if (ModelState.IsValid)
            {
                var tipoSanguineoDomain = Mapper.Map<TipoSanguineoViewModel, TipoSanguineo>(tipoSanguineo);
                _tipoSanguineoApp.Add(tipoSanguineoDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Tipo Sanguíneo registrado com sucesso."), true);
                return RedirectToAction("Index");
            }
            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            return View(tipoSanguineo);
        }

        // GET: TipoSanguineo/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var tipoSanguineo = _tipoSanguineoApp.GetById(id);
            var tipoSanguineoViewModel = Mapper.Map<TipoSanguineo, TipoSanguineoViewModel>(tipoSanguineo);
            return View(tipoSanguineoViewModel);
        }

        // POST: TipoSanguineo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(TipoSanguineoViewModel tipoSanguineo)
        {
            if (ModelState.IsValid)
            {
                var tipoSanguineoDomain = Mapper.Map<TipoSanguineoViewModel, TipoSanguineo>(tipoSanguineo);
                _tipoSanguineoApp.Update(tipoSanguineoDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Tipo Sanguíneo alterado com sucesso."), true);
                return RedirectToAction("Index");
            }
            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            return View(tipoSanguineo);
        }

        // GET: TipoSanguineo/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var tipoSanguineo = _tipoSanguineoApp.GetById(id);
            var tipoSanguineoViewModel = Mapper.Map<TipoSanguineo, TipoSanguineoViewModel>(tipoSanguineo);
            return View(tipoSanguineoViewModel);
        }

        // POST: TipoSanguineo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var tipoSanguineo = _tipoSanguineoApp.GetById(id);
            _tipoSanguineoApp.Remove(tipoSanguineo);
            this.MostrarMensagem(new Toast(MessageType.success, "Tipo Sanguíneo deletado com sucesso."), true);
            return RedirectToAction("Index");
        }
    }
}
