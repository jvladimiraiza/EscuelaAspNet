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
    public class CursoController : Controller
    {
        private readonly ILogger<CursoController> _logger;
        private EscuelaContext _context;

        public CursoController(ILogger<CursoController> logger, EscuelaContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Route("Curso/Index")]
        [Route("Curso/Index/{cursoId}")]
        public IActionResult Index(string cursoId)
        {
            if (!string.IsNullOrWhiteSpace(cursoId)) {
                var curso = _context.Cursos.Find(cursoId);
            } else {
                return View("MultiCurso", _context.Cursos);
            }
            return View(_context.Cursos.FirstOrDefault());
        }
        public IActionResult MultiCurso()
        {

            ViewBag.cosaDinamica = "La monja desde curso";
            ViewBag.Fecha = DateTime.Now;
            // return View(listaAsignaturas);
            return View("MultiCurso", _context.Cursos);
        }
        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            ViewBag.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                ViewBag.MensajeExra ="Curso Creado";
                return View("Index", curso);
            } else
            {
                return View(curso);
            }
        }
    }
}