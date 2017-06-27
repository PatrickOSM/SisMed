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
    public class SexosController : BaseController
    {
        private readonly ISexoAppService _sexoApp;

        public SexosController(ISexoAppService sexoApp)
        {
            _sexoApp = sexoApp;
        }

        // GET: Sexo
        [Authorize]
        public ActionResult Index()
        {
            var sexoViewModel = Mapper.Map<IEnumerable<Sexo>, IEnumerable<SexoViewModel>>(_sexoApp.GetAll());
            return View(sexoViewModel);
        }

        // GET: Sexo/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var sexo = _sexoApp.GetById(id);
            var sexoViewModel = Mapper.Map<Sexo, SexoViewModel>(sexo);
            return View(sexoViewModel);
        }

        // GET: Sexo/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sexo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(SexoViewModel sexo)
        {
            if (ModelState.IsValid)
            {
                var sexoDomain = Mapper.Map<SexoViewModel, Sexo>(sexo);
                _sexoApp.Add(sexoDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Sexo registrado com sucesso."), true);
                return RedirectToAction("Index");
            }
            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            return View(sexo);
        }

        // GET: Sexo/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var sexo = _sexoApp.GetById(id);
            var sexoViewModel = Mapper.Map<Sexo, SexoViewModel>(sexo);
            return View(sexoViewModel);
        }

        // POST: Sexo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(SexoViewModel sexo)
        {
            if (ModelState.IsValid)
            {
                var sexoDomain = Mapper.Map<SexoViewModel, Sexo>(sexo);
                _sexoApp.Update(sexoDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Sexo alterado com sucesso."), true);
                return RedirectToAction("Index");
            }
            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            return View(sexo);
        }

        // GET: Sexo/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var sexo = _sexoApp.GetById(id);
            var sexoViewModel = Mapper.Map<Sexo, SexoViewModel>(sexo);
            return View(sexoViewModel);
        }

        // POST: Sexo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var sexo = _sexoApp.GetById(id);
            _sexoApp.Remove(sexo);
            this.MostrarMensagem(new Toast(MessageType.success, "Sexo deletado com sucesso."), true);
            return RedirectToAction("Index");
        }
    }
}
