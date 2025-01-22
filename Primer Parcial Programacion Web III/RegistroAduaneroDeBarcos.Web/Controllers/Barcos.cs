using Microsoft.AspNetCore.Mvc;
using RegistroAduaneroDeBarcos.Logica.Services;
using RegistroAduaneroDeBarcos.Web.Models;

namespace RegistroAduaneroDeBarcos.Web.Controllers
{
    public class Barcos : Controller
    {

        private readonly IBarcoService _barcoService;

        public Barcos(IBarcoService _barcoService) 
        { 
            this._barcoService = _barcoService;
        }

        public IActionResult RegistrarBarco()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarBarco(BarcoModel barcoActual)
        {
            if(!ModelState.IsValid)
            {
                return View(barcoActual);
            }
            this._barcoService.GuardarBarco(barcoActual.ConvertirABarco());
            return RedirectToAction("ListadoBarcos");
        }

        public IActionResult ListadoBarcos()
        {
            return View(BarcoModel.ConvertirListaABarcoModel(this._barcoService.ObtenerBarcos()));
        }
    }
}
