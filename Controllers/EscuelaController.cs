using aspNet.Controllers;
using Microsoft.AspNetCore.Mvc;
using aspNet.Models;
public class EscuelaController: Controller
{
    private EscuelaContext _context;
    public IActionResult Index()
    {
        
        ViewBag.cosaDinamica = "La monja"; // para enviar datos que no vienen de un model

        var escuela = _context.Escuelas.FirstOrDefault();
        return View(escuela);
    }
    // para acceder a dbContent
    public EscuelaController(EscuelaContext context)
    {
        _context = context;
    }
}