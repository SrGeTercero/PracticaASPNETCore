using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        private List<SelectListItem> ObtenerListaDeCursosParaDropDownList()
        {
            var idCursos = from ids in _context.Cursos select ids;
            
            List<SelectListItem> listIdCursos = new List<SelectListItem>();
            foreach (var id in idCursos)
            {
                listIdCursos.Add(new SelectListItem(){Text = id.Nombre, Value = id.Id});
            }

            return listIdCursos;
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
        
        public IActionResult Create()
        {
            ViewBag.fecha = DateTime.Now;
            
            ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            ViewBag.fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                try
                {
                    var curso = _context.Cursos.Find(alumno.CursoId);

                    alumno.CursoId = curso.Id;

                    _context.Alumnos.Add(alumno);
                    _context.SaveChanges();

                    ViewBag.MensajeExtra = "Alumno Creado";
                    return View("Index", alumno);
                }catch(Exception ex){
                    ViewBag.MensajeException = ex.Message;
                    ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
                    return View(alumno);
                }
            }
            else
            {
                ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
                return View(alumno);
            }
        }

        public IActionResult Update(Alumno alumno)
        {
            ViewBag.IdAlumnoAEditar = alumno.Id;
            ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
            ViewBag.fecha = DateTime.Now;

            return View();
        }

        [HttpPost]
        public IActionResult Update(Alumno alumno, bool flag = false)
        {
            ViewBag.fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                try
                {
                    var curso = _context.Cursos.Find(alumno.CursoId);

                    alumno.CursoId = curso.Id;

                    _context.Alumnos.Update(alumno);
                    _context.SaveChanges();

                    ViewBag.MensajeExtra = "Alumno Actualizado";
                    return View("Index", alumno);
                }catch(Exception ex){
                    ViewBag.MensajeException = ex.Message;
                    ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
                    return View(alumno);
                }
            }
            else
            {
                ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
                return View(alumno);
            }
        }

        public IActionResult Delete(Alumno alumno)
        {
            ViewBag.IdAlumnoAEliminar = alumno.Id;
            ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
            ViewBag.fecha = DateTime.Now;

            return View();
        }

        [HttpPost]
        public IActionResult Delete(Alumno alumno, bool flag = false)
        {
            ViewBag.fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                try
                {
                    //var curso = _context.Cursos.Find(alumno.CursoId);

                    //alumno.CursoId = curso.Id;

                    _context.Alumnos.Remove(alumno);
                    _context.SaveChanges();

                    ViewBag.MensajeExtra = "Alumno Eliminado";
                    return View("MultiAlumno", _context.Alumnos);
                }catch(Exception ex){
                    ViewBag.MensajeException = ex.Message;
                    ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
                    return View(alumno);
                }
            }
            else
            {
                ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
                return View(alumno);
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