using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using aspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        public IActionResult create()
        {
            ViewData["cursoList"] = new SelectList(_context.Cursos, "Id", "Nombre");
            return View();
        }
        [HttpPost]
        public IActionResult create([Bind("Nombre, Apellidos, CursoId")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                _context.SaveChanges();
                ViewBag.Mensaje = "Se creo el alumno correctamente";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Mensaje = "Ocurrio un erro al guardar el registro !!!";
            ViewData["cursoList"] = new SelectList(_context.Cursos, "Id", "Nombre", alumno.CursoId);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var alumno = await _context.Alumnos.FindAsync(Id);
            if (Id == null || alumno == null)
            {
                ViewBag.mensaje = "El recurso que desea acceder no existe";
                return NotFound();
            }
            ViewData["cursoList"] = new SelectList(_context.Cursos, "Id", "Nombre", alumno.CursoId);
            return View(alumno);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nombre, Apellidos, CursoId, Id")] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["cursoList"] = new SelectList(_context.Cursos, "Id", "Nombre", alumno.CursoId);
            return View(alumno);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var alumno = _context.Alumnos.Find(id);
            if (alumno == null )
            {
                ViewBag.mensaje = "El registro no existe o fue eliminado";
            } else {
                _context.Alumnos.Remove(alumno);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}