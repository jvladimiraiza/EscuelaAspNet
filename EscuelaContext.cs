using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using aspNet.Models;
public class EscuelaContext: DbContext
{
    public DbSet<Escuela> Escuelas {get; set;}
    public DbSet<Alumno> Alumnos {get; set;}
    public DbSet<Asignatura> Asignaturas {get; set;}
    public DbSet<Curso> Cursos {get; set;}
    public DbSet<Evaluación> Evaluaciones {get; set;}
    public EscuelaContext(DbContextOptions<EscuelaContext> options): base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // este metodo se usa cuando se esta creando la bd
        base.OnModelCreating(modelBuilder);
        var escuela = new Escuela();
        escuela.Id = Guid.NewGuid().ToString();
        escuela.Nombre = "Platzi School";
        escuela.AnioCreacion = 2005;
        escuela.Dirección = "Loc. Mineros";
        escuela.Pais = "Bolivia";
        escuela.Ciudad = "Santa Cruz";
        escuela.TipoEscuela = TiposEscuela.Secundaria;

        // cargar los cursos de la escuela
        var cursos = CargarCursos(escuela);
        // por cada curso cargar la asignatura
        var asignaturas = CargarAsignaturas(cursos);
        // por cada curso cargar la alumnos
        var alumnos = CargarAlumno(cursos);
        // por cada curso cargar las evaluaciones

        modelBuilder.Entity<Escuela>().HasData(escuela);
        modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
        modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
        modelBuilder.Entity<Alumno>().HasData(alumnos);
        // hastData requiere si o si un arary y no una lista por eso se hace la conversion
    }

    private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
    {
        var listaCompleta = new List<Asignatura>();
        foreach (var curso in cursos)
        {
            var tmpList =  new List<Asignatura> {
                new Asignatura{
                    Id = Guid.NewGuid().ToString(),
                    CursoId = curso.Id,
                    Nombre = "Matemáticas"
                },
                new Asignatura{
                    Id = Guid.NewGuid().ToString(),
                    CursoId = curso.Id,
                    Nombre = "Educación Física"
                },
                new Asignatura
                {
                    Id = Guid.NewGuid().ToString(),
                    CursoId = curso.Id,
                    Nombre = "Castellano",
                },
                new Asignatura
                {
                    
                    Id = Guid.NewGuid().ToString(),
                    CursoId = curso.Id,
                    Nombre = "Ciencias Naturales",
                },
                new Asignatura
                {
                    
                    Id = Guid.NewGuid().ToString(),
                    CursoId = curso.Id,
                    Nombre = "Programacion",
                }
            };
            listaCompleta.AddRange(tmpList);
            // curso.Asignaturas = tmpList;
        }
        return listaCompleta;
    }

    private static List<Curso> CargarCursos(Escuela escuela)
    {
        return new List<Curso>(){
                    new Curso() {
                        Id = Guid.NewGuid().ToString(),
                        EscuelaId = escuela.Id,
                        Nombre = "101",
                        Jornada = TiposJornada.Mañana },
                    new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "201", Jornada = TiposJornada.Mañana},
                    new Curso   {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "301", Jornada = TiposJornada.Mañana},
                    new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "401", Jornada = TiposJornada.Tarde },
                    new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "501", Jornada = TiposJornada.Tarde},
        };
    }

    private List<Alumno> GenerarAlumnosAlAzar(int cantidad, Curso curso)
    {
        string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

        var listaAlumnos = from n1 in nombre1
            from n2 in nombre2
            from a1 in apellido1
            select new Alumno { 
                Nombre = $"{n1} {n2} {a1}" ,
                Id = Guid.NewGuid().ToString(),
                CursoId = curso.Id
                };

        return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
    }
    private List<Alumno> CargarAlumno(List<Curso> cursos)
    {
        var listaAlumnos = new List<Alumno>();
        Random rnd = new Random();
        foreach (var curso in cursos)
        {
            int cantRandom = rnd.Next(5, 20);
            var tmpList = GenerarAlumnosAlAzar(cantRandom, curso);
            listaAlumnos.AddRange(tmpList);
        }
        return listaAlumnos;
    }
}