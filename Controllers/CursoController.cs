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

        public IActionResult Create()
        {
            ViewBag.fecha = DateTime.Now;

            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            ViewBag.fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();

                curso.EscuelaId = escuela.Id;

                _context.Cursos.Add(curso);
                _context.SaveChanges();
                
                ViewBag.MensajeExtra = "Curso Creado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
            
        }

        public IActionResult Update(Curso curso)
        {
            ViewBag.IdCursoAEditar = curso.Id;
            ViewBag.fecha = DateTime.Now;

            return View();
        }

        [HttpPost]
        public IActionResult Update(Curso curso, bool flag = false)
        {
            ViewBag.IdCursoAEditar = curso.Id;
            ViewBag.fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();

                curso.EscuelaId = escuela.Id;

                _context.Cursos.Update(curso);
                _context.SaveChanges();
                
                ViewBag.MensajeExtra = "Curso Actualizado";
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            }
        }

        public IActionResult Delete(Curso curso)
        {
            ViewBag.IdCursoAEliminar = curso.Id;
            ViewBag.fecha = DateTime.Now;

            return View();
        }
        
        [HttpPost]
        public IActionResult Delete(Curso curso, bool flag = false)
        {
            ViewBag.fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();

                curso.EscuelaId = escuela.Id;

                _context.Cursos.Remove(curso);
                _context.SaveChanges();
                
                ViewBag.MensajeExtra = "Curso Eliminado";
                //return View("Index", curso);
                return View("MultiCurso",_context.Cursos);
            }
            else
            {
                return View(curso);
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