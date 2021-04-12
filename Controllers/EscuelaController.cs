using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Controllers
{

    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}