using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class AlumnoController : Controller
    {
        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }

    
        public IActionResult Index(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                var alumno = from alum in _context.Alumnos
                                where alum.Id == id
                                select alum;

                return View(alumno.SingleOrDefault());
            }else
            {
                return View("MultiAlumno",_context.Alumnos);
            }
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