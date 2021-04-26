using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{

    public class EscuelaController : Controller
    {
        private EscuelaContext _context;
        
        public IActionResult Index()
        {
            ViewBag.cosaDinamica = "Pulp Fiction";
            
            var escuela = _context.Escuelas.FirstOrDefault();

            return View(escuela);
        }

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}