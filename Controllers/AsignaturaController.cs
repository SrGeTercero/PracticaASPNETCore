using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using System.Linq;

namespace Proyecto.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //return View( new Asignatura{Nombre = "Programación", Id = Guid.NewGuid().ToString()} );

            return View(_context.Asignaturas.FirstOrDefault());
        }
        
        public IActionResult MultiAsignatura()
        {
            // var asignatura = new Asignatura{
            //     UniqueId = Guid.NewGuid().ToString(),
            //     Nombre = "Programación"
            // };

            // List<Asignatura> listaAsignaturas = new List<Asignatura>()
            // {
            //     new Asignatura{Nombre = "Matemáticas", Id = Guid.NewGuid().ToString()},
            //     new Asignatura{Nombre = "Educación Física", Id = Guid.NewGuid().ToString()},
            //     new Asignatura{Nombre = "Castellano", Id = Guid.NewGuid().ToString()},
            //     new Asignatura{Nombre = "Ciencias Naturales", Id = Guid.NewGuid().ToString()},
            //     new Asignatura{Nombre = "Programación", Id = Guid.NewGuid().ToString()}
            // };

            ViewBag.cosaDinamica = "PulpFiction";
            ViewBag.fecha = DateTime.Now;
            
            return View("MultiAsignatura",_context.Asignaturas);
        }
    }
}