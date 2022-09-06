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
    // [Route("[controller]")]
    public class AsignaturaController : Controller
    {
        private readonly ILogger<AsignaturaController> _logger;
        private EscuelaContext _context;
        public AsignaturaController(ILogger<AsignaturaController> logger, EscuelaContext context)
        {
            _logger = logger;
            _context = context;
        }

        // public IActionResult Index()
        // {
        //     return View(_context.Asignaturas.FirstOrDefault());
        // }
        // [HttpGet("{asignaturaId}")]
        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{asignaturaId}")]
        public IActionResult Index(string asignaturaId)
        {
            if (!string.IsNullOrWhiteSpace(asignaturaId))
            {
                var asignatura = from asig in _context.Asignaturas
                where asig.Id == asignaturaId
                select asig; 
                return View(asignatura.SingleOrDefault());
            } else {
                return View("MultiAsignatura", _context.Asignaturas);
            }
        }
        // [HttpGet]
        public IActionResult MultiAsignatura()
        {

            ViewBag.cosaDinamica = "La monja desde asignatura";
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAsignatura", _context.Asignaturas);
        }
    }
}