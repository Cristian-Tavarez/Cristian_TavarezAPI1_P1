using Microsoft.EntityFrameworkCore;
using Cristian_TavarezAPI1_P1.Contexto;
using Cristian_TavarezAPI1_P1.Models;

namespace Cristian_TavarezAPI1_P1.Services;

public class EntradasHuacalesService
{
    private readonly AppDbContext _context;

    public EntradasHuacalesService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EntradaHuacales>> ListarAsync(string? cliente)
    {
        var query = _context.EntradasHuacales.AsQueryable();

        if (!string.IsNullOrWhiteSpace(cliente))
            query = query.Where(x => x.NombreCliente.Contains(cliente));

        return await query.ToListAsync();
    }

    public async Task GuardarAsync(EntradaHuacales entrada)
    {
        if (entrada.IdEntrada == 0)
            _context.EntradasHuacales.Add(entrada);
        else
            _context.EntradasHuacales.Update(entrada);

        await _context.SaveChangesAsync();
    }

    public async Task<EntradaHuacales?> BuscarAsync(int id)
    {
        return await _context.EntradasHuacales.FindAsync(id);
    }

    public async Task EliminarAsync(int id)
    {
        var e = await BuscarAsync(id);
        if (e != null)
        {
            _context.EntradasHuacales.Remove(e);
            await _context.SaveChangesAsync();
        }
    }
}
