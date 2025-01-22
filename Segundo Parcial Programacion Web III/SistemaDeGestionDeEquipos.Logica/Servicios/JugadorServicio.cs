using SistemaDeGestionDeEquipos.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionDeEquipos.Logica.Servicios
{
    public interface IJugadorServicio
    {
        void CrearJugador(Jugador jugador);
        List<Jugador> ListarJugadores();
        List<Jugador> ListarJugadoresPorEquipo(int idEquipo);
    }
    
    public class JugadorServicio : IJugadorServicio
    {

        private GestionDeEquiposDBContext contexto;

        public JugadorServicio(GestionDeEquiposDBContext contexto)
        {
            this.contexto = contexto;
        }

        public void CrearJugador(Jugador jugador)
        {
            this.contexto.Jugadors.Add(jugador);
            this.contexto.SaveChanges();
        }

        public List<Jugador> ListarJugadores()
        {
            return this.contexto.Jugadors.ToList();
        }

        public List<Jugador> ListarJugadoresPorEquipo(int idEquipo)
        {
            return this.contexto.Jugadors.Where(equipo => equipo.IdEquipo == idEquipo).ToList();
        }
    }
}