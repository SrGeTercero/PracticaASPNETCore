using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using System.Linq;

namespace Proyecto.Controllers
{
    public class AlumnoController : Controller
    {
        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //return View( new Asignatura{Nombre = "Juan Perez", Id = Guid.NewGuid().ToString()} );
            return View(_context.Alumnos.FirstOrDefault());
        }
        
        public IActionResult MultiAlumno()
        {
            // var asignatura = new Asignatura{
            //     UniqueId = Guid.NewGuid().ToString(),
            //     Nombre = "Programación"
            // };

            //List<Alumno> listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.cosaDinamica = "PulpFiction";
            ViewBag.fecha = DateTime.Now;

            //asldkjals
            
            return View("MultiAlumno",_context.Alumnos);
        }
    }
}