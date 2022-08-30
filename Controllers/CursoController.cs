using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index()
        {
            return View(_context.Cursos.FirstOrDefault());
        }
        public IActionResult MultiCurso()
        {

            ViewBag.cosaDinamica = "La monja desde curso";
            ViewBag.Fecha = DateTime.Now;
            // return View(listaAsignaturas);
            return View("MultiCurso", _context.Cursos);
        }
    }
}