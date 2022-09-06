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
        private EscuelaContext _context;
        // para acceder a dbContent

        public AlumnoController(ILogger<AlumnoController> logger, EscuelaContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Route("Alumno/Index")]
        [Route("Alumno/Index/{alumnoId}")]
        public IActionResult Index(string alumnoId)
        {
            if (!string.IsNullOrWhiteSpace(alumnoId)) {
                ViewBag.cosaDinamica = "La monja"; // para enviar datos que no vienen de un model
                var alumno = from alum in _context.Alumnos
                where alum.Id == alumnoId
                select alum;
                return View(alumno.SingleOrDefault());
            } else {
                return View("MultiAlumno", _context.Alumnos);
            }
            //return View(_context.Alumnos.FirstOrDefault());
        }
        public IActionResult MultiAlumno()
        {
            ViewBag.cosaDinamica = "La monja desde Alumno";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAlumno", _context.Alumnos);
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
                    Id = Guid.NewGuid().ToString()
                    };

            return listaAlumnos.OrderBy((al) => al.Id).ToList();
        }
    }
}