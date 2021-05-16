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

        // public IActionResult Index()
        // {
        //     //return View( new Asignatura{Nombre = "Programación", Id = Guid.NewGuid().ToString()} );

        //     return View(_context.Asignaturas.FirstOrDefault());
        // }

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
        
        public IActionResult MultiAsignatura()
        {
            ViewBag.cosaDinamica = "PulpFiction";
            ViewBag.fecha = DateTime.Now;
            
            return View("MultiAsignatura",_context.Asignaturas);
        }
    }
}