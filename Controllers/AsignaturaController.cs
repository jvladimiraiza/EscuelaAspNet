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

        public AsignaturaController(ILogger<AsignaturaController> logger)
        {
            _logger = logger;
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
            return View(new Asignatura {Nombre = "Programacion", Id = Guid.NewGuid().ToString()});
        }
        public IActionResult MultiAsignatura()
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

            var listaAsignaturas = new List<Asignatura> () {
                new Asignatura {
                Nombre = "Matemáticas",
                Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                Nombre = "Educación Física",
                Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                Nombre = "Castellano",
                Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                Nombre = "Ciencias Naturales",
                Id = Guid.NewGuid ().ToString ()
                },
                new Asignatura {
                Nombre = "Programacion",
                Id = Guid.NewGuid ().ToString ()
                }
            };
            // return View(listaAsignaturas);
            return View("MultiAsignatura", listaAsignaturas);
        }
    }
}