using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            return View( new Asignatura{Nombre = "Juan Perez", Id = Guid.NewGuid().ToString()} );
        }
        
        public IActionResult MultiAlumno()
        {
            // var asignatura = new Asignatura{
            //     UniqueId = Guid.NewGuid().ToString(),
            //     Nombre = "Programación"
            // };

            List<Alumno> listaAlumnos = GenerarAlumnosAlAzar();

            ViewBag.cosaDinamica = "PulpFiction";
            ViewBag.fecha = DateTime.Now;

            //asldkjals
            
            return View("MultiAlumno",listaAlumnos);
        }

        private List<Alumno> GenerarAlumnosAlAzar()        
        {
            string[] nombre1 = {"German","Luis","Devora","Irma","Alison","Juan","Pedro"};
            string[] apellido1 = {"Sandoval","Orantes","Rodriguez","Perez","Alvarez","Alvizuez","Cuellar"};
            string[] nombre2 = {"Arturo","Jose","Yolanda","David","Diana","Nicole","Jonas"};

            //como hacer la convinatoria de los elmentos de estos arreglos.
            //usaremos linq, sql embebido en c#
            var listaDeAlumnos = from n1 in nombre1
                                    from n2 in nombre2
                                    from a1 in apellido1
                                    select new Alumno{
                                        Nombre = $"{n1} {n2} {a1}",
                                        Id = Guid.NewGuid().ToString()
                                        };
            
            return listaDeAlumnos.OrderBy((al) => al.Id).ToList();
        }
    }
}