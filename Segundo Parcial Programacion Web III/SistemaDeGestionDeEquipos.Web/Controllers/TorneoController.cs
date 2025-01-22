using Microsoft.AspNetCore.Mvc;
using SistemaDeGestionDeEquipos.Data.Entidades;
using SistemaDeGestionDeEquipos.Logica.Servicios;

namespace SistemaDeGestionDeEquipos.Web.Controllers
{
    public class TorneoController : Controller
    {

        private IJugadorServicio jugadorServicio;
        private IEquipoServicio equipoServicio;

        public TorneoController(ILogger<HomeController> logger, IJugadorServicio jugadorServicio, IEquipoServicio equipoServicio)
        {
            this.jugadorServicio = jugadorServicio;
            this.equipoServicio = equipoServicio;
        }

        [HttpGet]
        public IActionResult CrearJugador()
        {
            ViewBag.Equipos = this.equipoServicio.ListarEquipos();
            return View();
        }

        [HttpPost]
        public IActionResult CrearJugador(Jugador jugador)
        {
            ViewBag.Equipos = this.equipoServicio.ListarEquipos();

            if (!ModelState.IsValid)
                return View(jugador);

            this.jugadorServicio.CrearJugador(jugador);

            return RedirectToAction("ListarJugadores");
        }

        public IActionResult ListarJugadores(int? idEquipo)
        {
            ViewBag.IdEquipoElegido = idEquipo;
            ViewBag.Equipos = this.equipoServicio.ListarEquipos();

            if (idEquipo.HasValue)
            {
                var jugadores = this.jugadorServicio.ListarJugadoresPorEquipo(idEquipo.Value);
                return View(jugadores);
            }
            else
            {
                var jugadores = this.jugadorServicio.ListarJugadores();
                return View(jugadores);
            }
        }
    }
}