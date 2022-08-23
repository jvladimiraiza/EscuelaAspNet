using aspNet.Controllers;
using Microsoft.AspNetCore.Mvc;
using aspNet.Models;
public class EscuelaController: Controller
{
    public IActionResult Index()
    {
        var escuela = new Escuela();
        escuela.UniqueId = Guid.NewGuid().ToString();
        escuela.Nombre = "Platzi School";
        escuela.AnioCreacion = 2005;
        escuela.Dirección = "Loc. Mineros";
        escuela.Pais = "Bolivia";
        escuela.Ciudad = "Santa Cruz";
        escuela.TipoEscuela = TiposEscuela.Secundaria;
        ViewBag.cosaDinamica = "La monja"; // para enviar datos que no vienen de un model
        return View(escuela);
    }
}