using System;
using System.ComponentModel.DataAnnotations;

namespace Cristian_TavarezAPI1_P1.Models
{
    public class EntradasHuacales
    {
        [Key]
        public int ViajeId { get; set; }

        [Required]
        public string FechaId { get; set; }

        [Required]
        public string Descripcion { get; set; }  

    }
}
