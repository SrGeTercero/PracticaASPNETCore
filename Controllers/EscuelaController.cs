using System;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{

    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AñoCreacion = 2005;
            escuela.UniqueId = Guid.NewGuid().ToString();
            escuela.Nombre = "San Mateo Academy";
            escuela.Ciudad = "Guatemala";
            escuela.Pais = "Guatemala";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Direccion = "5ta calle b, 10-15";

            ViewBag.cosaDinamica = "Pulp Fiction";

            return View(escuela);
        }
    }
}