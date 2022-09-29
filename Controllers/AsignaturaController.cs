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
        public IActionResult create()
        {   
            ViewData["cursoList"] = new SelectList(_context.Cursos, "Id", "Nombre");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nombre,CursoId")] Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignatura);
                await _context.SaveChangesAsync();
                ViewBag.Mensaje = "Se creo la asignatura correctamente";
                return RedirectToAction(nameof(Index));
            } 
            ViewBag.Mensaje = "Ocurrio un error al guardar el registro!!!";
            ViewData["cursoList"] = new SelectList(_context.Cursos, "Id", "Nombre", asignatura.CursoId);
            return View(asignatura);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var asignatura = await _context.Asignaturas.FindAsync(Id);
            if (Id == null || asignatura == null)
            {
                ViewBag.mensaje = "El recurso que desea acceder no existe";
                return NotFound();
            }
            ViewData["cursoList"] = new SelectList(_context.Cursos, "Id", "Nombre", asignatura.CursoId);
            return View(asignatura);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string Id, [Bind("Nombre,CursoId, Id")] Asignatura asignatura)
        {
            if (Id != asignatura.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExistAsignatura(asignatura.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["cursoList"] = new SelectList(_context.Cursos, "Id", "Nombre", asignatura.CursoId);
            return View(asignatura);
        }
        private bool ExistAsignatura(string id)
        {
            return _context.Asignaturas.Any(e =>e.Id == id);
        }
        public async Task<IActionResult> Delete(string Id)
        {
            var asignatura = await _context.Cursos.FindAsync(Id);
            if (asignatura != null)
            {
                _context.Cursos.Remove(asignatura);
                await _context.SaveChangesAsync();
            } else {
                ViewBag.mensaje = "El registro no existe o fue eliminado";
            }
            return Redirect("/asignatura/Index");
        }
    }
}