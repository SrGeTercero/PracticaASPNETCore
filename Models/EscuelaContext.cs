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
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "San Mateo University";
            escuela.AñoCreacion = 2005;
            escuela.Pais = "Guatemala";
            escuela.Ciudad = "Guatemala";
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Direccion = "5ta calle b, 10-15";

            //cargar curos de la escuela
            var cursos = CargarCursos(escuela);

            //x cada curso, cargar asignaturas
            var asignaturas = CargarAsignaturas(cursos);

            //x cada curso, cargar alumnos
            var alumnos = CargarAlumnos(cursos);

            //TAREA, cargar evaluaciones

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            List<Asignatura> listaCompleta = new List<Asignatura>();
            foreach (var curso in cursos)
            {
                var tmpList = new List<Asignatura>()
                {
                    new Asignatura { Id = Guid.NewGuid().ToString(), Nombre = "Matemáticas", CursoId = curso.Id},
                    new Asignatura { Id = Guid.NewGuid().ToString(), Nombre = "Educación Física", CursoId = curso.Id},
                    new Asignatura { Id = Guid.NewGuid().ToString(), Nombre = "Castellano", CursoId = curso.Id},
                    new Asignatura { Id = Guid.NewGuid().ToString(), Nombre = "Ciencias Naturales", CursoId = curso.Id},
                    new Asignatura { Id = Guid.NewGuid().ToString(), Nombre = "Programación", CursoId = curso.Id}
                };
                listaCompleta.AddRange(tmpList);
                //curso.Asignaturas = tmpList;
            }

            return listaCompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>()
            {
                new Curso()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "101",
                    Jornada = TiposJornada.Mañana,
                    EscuelaId = escuela.Id
                },
                new Curso()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "102",
                    Jornada = TiposJornada.Mañana,
                    EscuelaId = escuela.Id
                },
                new Curso()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "103",
                    Jornada = TiposJornada.Mañana,
                    EscuelaId = escuela.Id
                },
                new Curso()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "104",
                    Jornada = TiposJornada.Mañana,
                    EscuelaId = escuela.Id
                },
                new Curso()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "105",
                    Jornada = TiposJornada.Mañana,
                    EscuelaId = escuela.Id
                }
            };
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos){
            var listaAlumno = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5,20);
                var tmpList = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumno.AddRange(tmpList);
            }
            return listaAlumno;
        }
        
        private List<Alumno> GenerarAlumnosAlAzar(
            Curso curso,
            int cantidadAlumnos)        
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
                                        Id = Guid.NewGuid().ToString(),
                                        Nombre = $"{n1} {n2} {a1}",
                                        CursoId = curso.Id
                                        };
            
            return listaDeAlumnos.OrderBy((al) => al.Id).Take(cantidadAlumnos).ToList();
        }

    }

}