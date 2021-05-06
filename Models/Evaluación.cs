using System;

namespace Proyecto.Models
{
    public class Evaluación : ObjetoEscuelaBase
    {
        //referencias hacia padres
        public Alumno Alumno { get; set; }
        public string AlumnoId { get; set; }
        public Asignatura Asignatura { get; set; }
        public string AsignaturaId { get; set; }
        
        //propiedad normal
        public float Nota { get; set; }

        
        //SOBREESCRITURA DE METODO
        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }

    }
}