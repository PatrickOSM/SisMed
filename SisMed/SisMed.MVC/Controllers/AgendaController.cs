using System.Web.Mvc;

namespace SisMed.MVC.Controllers
{
    public class AgendaController : Controller
    {
        // GET: Agenda
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}