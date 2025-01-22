using Microsoft.AspNetCore.Mvc;
using SistemaDeGestionDeEquipos.Data.Entidades;
using SistemaDeGestionDeEquipos.Logica.Servicios;
using System.Diagnostics;

namespace SistemaDeGestionDeEquipos.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}