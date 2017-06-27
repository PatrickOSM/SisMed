using System;
using AutoMapper;
using SisMed.Application.Interface;
using SisMed.Domain.Entities;
using SisMed.MVC.ViewModels;
using SisMed.Util.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using SisMed.Util;
using SisMed.Util.Enums;

namespace SisMed.MVC.Controllers
{
    public class CargosController : BaseController
    {
        private readonly ICargoAppService _cargoApp;

        public CargosController(ICargoAppService cargoApp)
        {
            _cargoApp = cargoApp;
        }

        // GET: Cargos
        [Authorize]
        public ActionResult Index()
        {
            var cargoViewModel = Mapper.Map<IEnumerable<Cargo>, IEnumerable<CargoViewModel>>(_cargoApp.GetAll());
            return View(cargoViewModel);
        }

        // GET: Cargos/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var cargo = _cargoApp.GetById(id);
            var cargoViewModel = Mapper.Map<Cargo, CargoViewModel>(cargo);
            return View(cargoViewModel);
        }

        // GET: Cargos/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CargoViewModel cargo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cargoDomain = Mapper.Map<CargoViewModel, Cargo>(cargo);
                    _cargoApp.Add(cargoDomain);
                    this.MostrarMensagem(new Toast(MessageType.success, "Cargo registrado com sucesso."), true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
                return RedirectToAction("Index");
            }

            return View(cargo);
        }

        // GET: Cargos/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var cargo = _cargoApp.GetById(id);
            var cargoViewModel = Mapper.Map<Cargo, CargoViewModel>(cargo);
            return View(cargoViewModel);
        }

        // POST: Cargos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(CargoViewModel cargo)
        {
            if (ModelState.IsValid)
            {
                var cargoDomain = Mapper.Map<CargoViewModel, Cargo>(cargo);
                _cargoApp.Update(cargoDomain);
                this.MostrarMensagem(new Toast(MessageType.success, "Cargo alterado com sucesso."), true);

                return RedirectToAction("Index");
            }
            this.MostrarMensagem(new Toast(MessageType.info, "Verifique as informações inseridas."));
            return View(cargo);
        }

        // GET: Cargos/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var cargo = _cargoApp.GetById(id);
            var cargoViewModel = Mapper.Map<Cargo, CargoViewModel>(cargo);
            return View(cargoViewModel);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var cargo = _cargoApp.GetById(id);
            _cargoApp.Remove(cargo);
            this.MostrarMensagem(new Toast(MessageType.success, "Cargo deletado com sucesso."), true);
            return RedirectToAction("Index");
        }
    }
}
