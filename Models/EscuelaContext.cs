using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas {get; set;}
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.AñoCreacion = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "San Mateo University";
            escuela.Ciudad = "Guatemala";
            escuela.Pais = "Guatemala";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Direccion = "5ta calle b, 10-15";

            modelBuilder.Entity<Escuela>().HasData(escuela);

            modelBuilder.Entity<Asignatura>().HasData(
                new Asignatura{Nombre = "Matemáticas", Id = Guid.NewGuid().ToString()},
                new Asignatura{Nombre = "Educación Física", Id = Guid.NewGuid().ToString()},
                new Asignatura{Nombre = "Castellano", Id = Guid.NewGuid().ToString()},
                new Asignatura{Nombre = "Ciencias Naturales", Id = Guid.NewGuid().ToString()},
                new Asignatura{Nombre = "Programación", Id = Guid.NewGuid().ToString()}
            );

            modelBuilder.Entity<Alumno>().HasData(GenerarAlumnosAlAzar().ToArray());

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