using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cristian_TavarezAPI1_P1.Models;

public class EntradaHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required]
    public string NombreCliente { get; set; } = "";

    public ICollection<EntradaHuacalDetalle>? Detalles { get; set; }

    [NotMapped]
    public int CantidadTotal =>
        Detalles?.Sum(d => d.Cantidad) ?? 0;

    [NotMapped]
    public decimal TotalDinero =>
        Detalles?.Sum(d => d.Cantidad * d.Precio) ?? 0;

    [NotMapped]
    public string TiposResumen =>
    Detalles == null || !Detalles.Any()
        ? ""
        : string.Join(", ",
            Detalles.Select(d =>
                $"{d.TipoHuacal?.Descripcion} ({d.Cantidad})"));
}


