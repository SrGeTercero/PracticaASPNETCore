using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Proyecto.Controllers
{
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }

        // public IActionResult Index()
        // {
        //     //return View( new Asignatura{Nombre = "Programación", Id = Guid.NewGuid().ToString()} );

        //     return View(_context.Asignaturas.FirstOrDefault());
        // }

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

        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string asignaturaId)
        {
            if(!string.IsNullOrEmpty(asignaturaId))
            {
                var asignatura = from asig in _context.Asignaturas
                                where asig.Id == asignaturaId
                                select asig;

                return View(asignatura.SingleOrDefault());
            }else
            {
                return View("MultiAsignatura",_context.Asignaturas);
            }
        }
        
        public IActionResult Create()
        {
            ViewBag.fecha = DateTime.Now;
            
            ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
        {
            ViewBag.fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                try
                {
                    var curso = _context.Cursos.Find(asignatura.CursoId);

                    asignatura.CursoId = curso.Id;

                    _context.Asignaturas.Add(asignatura);
                    _context.SaveChanges();

                    ViewBag.MensajeExtra = "Asignatura Creado";
                    return View("Index", asignatura);
                }catch(Exception ex){
                    ViewBag.MensajeException = ex.Message;
                    ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
                    return View(asignatura);
                }
            }
            else
            {
                ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
                return View(asignatura);
            }
        }

        public IActionResult Update(Asignatura asignatura)
        {
            ViewBag.IdAsignaturaAEditar = asignatura.Id;
            ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
            ViewBag.fecha = DateTime.Now;

            return View();
        }

        [HttpPost]
        public IActionResult Update(Asignatura asignatura, bool flag = false)
        {
            ViewBag.fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                try
                {
                    var curso = _context.Cursos.Find(asignatura.CursoId);

                    asignatura.CursoId = curso.Id;

                    _context.Asignaturas.Update(asignatura);
                    _context.SaveChanges();

                    ViewBag.MensajeExtra = "Asignatura Actualizado";
                    return View("Index", asignatura);
                }catch(Exception ex){
                    ViewBag.MensajeException = ex.Message;
                    ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
                    return View(asignatura);
                }
            }
            else
            {
                ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
                return View(asignatura);
            }
        }
        public IActionResult Delete(Asignatura asignatura)
        {
            ViewBag.IdAsignaturaAEliminar = asignatura.Id;
            ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
            ViewBag.fecha = DateTime.Now;

            return View();
        }

        [HttpPost]
        public IActionResult Delete(Asignatura asignatura, bool flag = false)
        {
            ViewBag.fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                try
                {
                    //var curso = _context.Cursos.Find(alumno.CursoId);

                    //alumno.CursoId = curso.Id;

                    _context.Asignaturas.Remove(asignatura);
                    _context.SaveChanges();

                    ViewBag.MensajeExtra = "Asignatura Eliminado";
                    return View("MultiAsignatura", _context.Asignaturas);
                }catch(Exception ex){
                    ViewBag.MensajeException = ex.Message;
                    ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
                    return View(asignatura);
                }
            }
            else
            {
                ViewBag.idCursosDisponibles = ObtenerListaDeCursosParaDropDownList();
                return View(asignatura);
            }

        }
        public IActionResult MultiAsignatura()
        {
            ViewBag.cosaDinamica = "PulpFiction";
            ViewBag.fecha = DateTime.Now;
            
            return View("MultiAsignatura",_context.Asignaturas);
        }
    }
}