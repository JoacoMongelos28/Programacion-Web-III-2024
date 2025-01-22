using SistemaDeGestionDeEquipos.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionDeEquipos.Logica.Servicios
{
    public interface IEquipoServicio
    {
        List<Equipo> ListarEquipos();
    }
    
    public class EquipoServicio : IEquipoServicio
    {

        private GestionDeEquiposDBContext contexto;

        public EquipoServicio(GestionDeEquiposDBContext contexto)
        {
            this.contexto = contexto;
        }

        public List<Equipo> ListarEquipos()
        {
            return this.contexto.Equipos.Where(equipo => equipo.ParticipaEnTorneo).
                OrderBy(equipo => equipo.NombreEquipo).ToList();
        }
    }
}