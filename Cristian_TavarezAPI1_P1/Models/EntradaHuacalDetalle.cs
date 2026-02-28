using System.ComponentModel.DataAnnotations.Schema;

namespace Cristian_TavarezAPI1_P1.Models
{
    public class EntradaHuacalDetalle
    {
        public int Id { get; set; }

        public int EntradaId { get; set; }
        public EntradaHuacales? Entrada { get; set; }

        public int TipoId { get; set; }
        public TipoHuacal? TipoHuacal { get; set; }

        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
    }
}