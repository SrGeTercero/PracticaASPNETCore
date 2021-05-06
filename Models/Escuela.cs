using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public class Escuela : ObjetoEscuelaBase
    {
        //propiedades normales
        public int AñoCreacion{get; set;}
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public string Direccion { get; set; }
        
        //referencia hacia hijos
        public List<Curso> Cursos { get; set; }


        //CONSTRUCTORES
         //Nuevo constructor, basado en lenguajes funcional.
        public Escuela(string nombre, int añoCreacion) => (Nombre, AñoCreacion) = (nombre, añoCreacion);

        public Escuela(string nombre, int añoCreacion, TiposEscuela tiposEscuela, 
            string pais = "", 
            string ciudad = "")
        {
            //parametros opcionales o con valor por defecto
            (Nombre, AñoCreacion) = (nombre, añoCreacion);
            Pais = pais;
            Ciudad = ciudad;
        }

        public Escuela()
        {
            
        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine}Pais: {Pais}, Ciudad: {Ciudad}";
        }

        
    }
}