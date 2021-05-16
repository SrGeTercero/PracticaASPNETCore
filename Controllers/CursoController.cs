using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class CursoController : Controller
    {
        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }

    
        public IActionResult Index(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                var curso = from cur in _context.Cursos
                                where cur.Id == id
                                select cur;

                return View(curso.SingleOrDefault());
            }else
            {
                return View("MultiCurso",_context.Cursos);
            }
        }
        
        public IActionResult MultiCurso()
        {
            // var asignatura = new Asignatura{
            //     UniqueId = Guid.NewGuid().ToString(),
            //     Nombre = "Programación"
            // };

            //List<Alumno> listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.cosaDinamica = "PulpFiction";
            ViewBag.fecha = DateTime.Now;

            //asldkjals
            
            return View("MultiCurso",_context.Cursos);
        }
    }
}