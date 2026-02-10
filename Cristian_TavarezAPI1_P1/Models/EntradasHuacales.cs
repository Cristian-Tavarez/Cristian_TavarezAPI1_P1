using System.ComponentModel.DataAnnotations;

namespace Cristian_TavarezAPI1_P1.Models;

public class EntradaHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required]
    public string NombreCliente { get; set; } = "";

    [Required]
    public int Cantidad { get; set; }

    [Required]
    public decimal Precio { get; set; }
}
 


