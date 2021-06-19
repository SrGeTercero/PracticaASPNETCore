using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        //override
        [Required]
        public override string Nombre {get; set;}
   
        //referencia hacia padre
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }

        //propiedad normal
        public TiposJornada Jornada { get; set; }
        public string Direccion { get; set; }
        
        //referencia hacia hijos
        public List<Asignatura> Asignaturas {get; set;}
        public List<Alumno> Alumnos {get; set;}

    }
}