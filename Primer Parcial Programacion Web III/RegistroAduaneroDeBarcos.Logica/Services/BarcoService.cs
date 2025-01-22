using RegistroAduaneroDeBarcos.Entidades;

namespace RegistroAduaneroDeBarcos.Logica.Services
{
    public interface IBarcoService
    {
        void GuardarBarco(Barco barco);
        List<Barco> ObtenerBarcos();
    }

    public class BarcoService : IBarcoService
    {

        private static List<Barco> ListadoDeBarcos = new List<Barco>();


        public void GuardarBarco(Barco barco)
        {
            //Tasa = (Antiguedad * 0.10) + (Tripulacion maxima / 2).
            barco.Tasa = (decimal) (barco.Antiguedad * 0.10) + (barco.TripulacionMaxima / 2);
            barco.IdBarco = ListadoDeBarcos.Count == 0 ? 1 : ListadoDeBarcos.Max(barco => barco.IdBarco) + 1;
            ListadoDeBarcos.Add(barco);
        }

        public List<Barco> ObtenerBarcos()
        {
            return ListadoDeBarcos;
        }
    }
}
