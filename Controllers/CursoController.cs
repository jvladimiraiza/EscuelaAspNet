using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using aspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                // return View("Index", curso);
                return Redirect("/curso/Index");
            } else
            {
                return View(curso);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(String id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                ViewBag.mensaje = "El curso que intenta eliminar no existe";
                return RedirectToAction("Error404", "Error");
                // return View(curso);
                // throw new EscuelaException("El recurso que desea acceder no existe");
            }
            return View(curso);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nombre,Jornada,Direccion,EscuelaId,Id")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }
        // public async Task<IActionResult> Delete(string id)
        // {
        //     Console.Write("GET DELETE");
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var curso = await _context.Cursos.FirstOrDefaultAsync(m => m.Id == id);
        //     if (curso == null)
        //     {
        //         return NotFound();
        //     }

        //     return View("Index");
        // }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
            } else {
                ViewBag.mensaje = "El registro no existe o fue eliminado";
            }
            return Redirect("/curso/Index");
        }
    }
}