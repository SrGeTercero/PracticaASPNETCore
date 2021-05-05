using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            return View( new Asignatura{Nombre = "Programación", UniqueId = Guid.NewGuid().ToString()} );
        }
        
        public IActionResult MultiAsignatura()
        {
            // var asignatura = new Asignatura{
            //     UniqueId = Guid.NewGuid().ToString(),
            //     Nombre = "Programación"
            // };

            List<Asignatura> listaAsignaturas = new List<Asignatura>()
            {
                new Asignatura{Nombre = "Matemáticas", UniqueId = Guid.NewGuid().ToString()},
                new Asignatura{Nombre = "Educación Física", UniqueId = Guid.NewGuid().ToString()},
                new Asignatura{Nombre = "Castellano", UniqueId = Guid.NewGuid().ToString()},
                new Asignatura{Nombre = "Ciencias Naturales", UniqueId = Guid.NewGuid().ToString()},
                new Asignatura{Nombre = "Programación", UniqueId = Guid.NewGuid().ToString()}
            };

            ViewBag.cosaDinamica = "PulpFiction";
            ViewBag.fecha = DateTime.Now;
            
            return View("MultiAsignatura",listaAsignaturas);
        }
    }
}