using System.ComponentModel.DataAnnotations;

namespace Cristian_TavarezAPI1_P1.Models
{
    public class TipoHuacal
    {
        [Key]
        public int TipoId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int Existencia { get; set; }

        public ICollection<EntradaHuacalDetalle>? Detalles { get; set; }
    }
}