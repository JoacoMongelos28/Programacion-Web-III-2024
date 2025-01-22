using RegistroAduaneroDeBarcos.Entidades;
using System.ComponentModel.DataAnnotations;

namespace RegistroAduaneroDeBarcos.Web.Models
{
    public class BarcoModel
    {

        public int IdBarco { get; set; }
        [StringLength(20), Required]
        public string Nombre { get; set; }
        [Range(1, 199), Required]
        public int Antiguedad { get; set; }
        [Range(1, 499), Required]
        public int TripulacionMaxima { get; set;}
        public decimal Tasa { get; set; }
        
        public BarcoModel() { }

        public BarcoModel(Barco Barco)
        {
            IdBarco = Barco.IdBarco;
            Nombre = Barco.Nombre;
            Antiguedad = Barco.Antiguedad;
            TripulacionMaxima = Barco.TripulacionMaxima;
            Tasa = Barco.Tasa;
        }

        public Barco ConvertirABarco()
        {
            return new Barco
            {
                IdBarco = IdBarco,
                Nombre = Nombre,
                Antiguedad = Antiguedad,
                TripulacionMaxima = TripulacionMaxima
            };
        }

        public static List<BarcoModel> ConvertirListaABarcoModel(List<Barco> listaABarcoModel)
        {
            return listaABarcoModel.Select(barco => new BarcoModel(barco)).ToList();
        }
    }
}
