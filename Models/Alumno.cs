using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Alumno : ObjetoEscuelaBase
    {
        //override
        [Required]
        public override string Nombre {get; set;}
        
        //referencia hacia padre
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        
        //referencia hacia hijo
        public List<Evaluación> Evaluaciones { get; set; }
    }
}