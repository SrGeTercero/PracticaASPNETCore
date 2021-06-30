using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        //override
        [Display(Prompt ="Menor o igual a 5")]
        [Required(ErrorMessage = "El nombre del curso es requerido") ]
        [StringLength(5, ErrorMessage ="El nombre del curso no puede ser mayor a 5 caracteres")]
        public override string Nombre {get; set;}
   
        //referencia hacia padre
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }

        //propiedad normal
        public TiposJornada Jornada { get; set; }
        
        [Display(Prompt ="Dirección de correspondencia", Name ="Address")]
        [Required(ErrorMessage = "Se requiere incluir una dirección")]
        [MinLength(10, ErrorMessage = "La longitud minima de la dirección es 10 caracteres")]
        public string Direccion { get; set; }
        
        //referencia hacia hijos
        public List<Asignatura> Asignaturas {get; set;}
        public List<Alumno> Alumnos {get; set;}

    }
}