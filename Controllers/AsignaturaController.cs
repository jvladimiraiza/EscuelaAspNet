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
    public class AsignaturaController : Controller
    {
        private readonly ILogger<AsignaturaController> _logger;
        private EscuelaContext _context;
        public AsignaturaController(ILogger<AsignaturaController> logger, EscuelaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // var asignatura = new Asignatura();
            // asignatura.UniqueId = Guid.NewGuid().ToString();
            // asignatura.Nombre = "Programacion";
            // ViewBag.cosaDinamica = "La monja"; // para enviar datos que no vienen de un model
            // ViewBag.Fecha = DateTime.Now;

            // var asignatura = new Asignatura {
            //     UniqueId = Guid.NewGuid().ToString(),
            //     Nombre = "Programacion"
            // };
            return View(_context.Asignaturas.FirstOrDefault());
        }
        public IActionResult MultiAsignatura()
        {

            ViewBag.cosaDinamica = "La monja desde asignatura";
            ViewBag.Fecha = DateTime.Now;
            // return View(listaAsignaturas);
            return View("MultiAsignatura", _context.Asignaturas);
        }
    }
}