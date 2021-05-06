using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public class Alumno : ObjetoEscuelaBase
    {
        //referencia hacia padre
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        
        //referencia hacia hijo
        public List<Evaluación> Evaluaciones { get; set; }
    }
}