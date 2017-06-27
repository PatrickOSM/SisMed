using System;
using System.Web.Mvc;
using SisMed.Domain.Interfaces.Repositories;

namespace SisMed.MVC.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: Usuarios
        [Authorize]
        public ActionResult Index()
        {
            return View(_usuarioRepository.GetAll());
        }

        // GET: Usuarios/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            return View(_usuarioRepository.GetById(Convert.ToInt32(id)));
        }

        [Authorize]
        public ActionResult DesativarLock(string id)
        {
            _usuarioRepository.DesativarLock(id);
            return RedirectToAction("Index");
        }
    }
}