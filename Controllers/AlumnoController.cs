using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using aspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspNet.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly ILogger<AlumnoController> _logger;

        public AlumnoController(ILogger<AlumnoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new Alumno {Nombre = "Vladimir Aiza", UniqueId = Guid.NewGuid().ToString()});
        }
        public IActionResult MultiAlumno()
        {

            // var listaAlumno = new List<Alumno> () {
            //     new Alumno {
            //     Nombre = "Selena Labrayo",
            //     UniqueId = Guid.NewGuid ().ToString ()
            //     },
            //     new Alumno {
            //     Nombre = "Laura Callejas",
            //     UniqueId = Guid.NewGuid ().ToString ()
            //     },
            //     new Alumno {
            //     Nombre = "Daniel Olivares",
            //     UniqueId = Guid.NewGuid ().ToString ()
            //     },
            //     new Alumno {
            //     Nombre = "Rosio Aiza Rodriguez",
            //     UniqueId = Guid.NewGuid ().ToString ()
            //     },
            //     new Alumno {
            //     Nombre = "Delma Aiza",
            //     UniqueId = Guid.NewGuid ().ToString ()
            //     }
            // };

            var listaAlumno = GenerarAlumnosAlAzar();
            return View("MultiAlumno", listaAlumno);
        }
        private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                from n2 in nombre2
                from a1 in apellido1
                select new Alumno { 
                    Nombre = $"{n1} {n2} {a1}" ,
                    UniqueId = Guid.NewGuid().ToString()
                    };

            return listaAlumnos.OrderBy((al) => al.UniqueId).ToList();
        }
    }
}