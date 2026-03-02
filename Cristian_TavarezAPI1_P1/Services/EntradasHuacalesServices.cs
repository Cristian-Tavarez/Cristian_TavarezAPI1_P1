using Cristian_TavarezAPI1_P1.Contexto;
using Cristian_TavarezAPI1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace Cristian_TavarezAPI1_P1.Services;

public class EntradasHuacalesService
{
    private readonly AppDbContext _context;

    public EntradasHuacalesService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EntradaHuacales>> ListarAsync(string? cliente = null)
    {
        var query = _context.EntradasHuacales
            .Include(e => e.Detalles)
             .ThenInclude(d => d.TipoHuacal)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(cliente))
        {
            query = query.Where(x =>
                x.NombreCliente != null &&
                x.NombreCliente.Contains(cliente));
        }

        return await query.ToListAsync();
    }
    public async Task<List<TipoHuacal>> ListarTiposAsync()
    {
        return await _context.TiposHuacales.ToListAsync();
    }

    public async Task GuardarAsync(EntradaHuacales entrada)
    {
        if (entrada.IdEntrada == 0)
        {
            
            foreach (var item in entrada.Detalles!)
            {
                var tipo = await _context.TiposHuacales.FindAsync(item.TipoId);
                if (tipo != null)
                    tipo.Existencia += item.Cantidad;
            }

            _context.EntradasHuacales.Add(entrada);
        }
        else
        {
            var anterior = await _context.EntradasHuacales
                .Include(e => e.Detalles)
                .FirstOrDefaultAsync(e => e.IdEntrada == entrada.IdEntrada);

            if (anterior != null)
            {
                
                foreach (var item in anterior.Detalles!)
                {
                    var tipo = await _context.TiposHuacales.FindAsync(item.TipoId);
                    if (tipo != null)
                        tipo.Existencia -= item.Cantidad;
                }

                
                foreach (var item in entrada.Detalles!)
                {
                    var tipo = await _context.TiposHuacales.FindAsync(item.TipoId);
                    if (tipo != null)
                        tipo.Existencia += item.Cantidad;
                }

                _context.Entry(anterior).CurrentValues.SetValues(entrada);
                anterior.Detalles = entrada.Detalles;
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task<EntradaHuacales?> BuscarAsync(int id)
    {
        return await _context.EntradasHuacales
            .Include(e => e.Detalles)
            .FirstOrDefaultAsync(e => e.IdEntrada == id);
    }

    public async Task EliminarAsync(int id)
    {
        var entrada = await _context.EntradasHuacales
            .Include(e => e.Detalles)
            .FirstOrDefaultAsync(e => e.IdEntrada == id);

        if (entrada != null)
        {
            foreach (var item in entrada.Detalles!)
            {
                var tipo = await _context.TiposHuacales.FindAsync(item.TipoId);
                if (tipo != null)
                    tipo.Existencia -= item.Cantidad;
            }

            _context.EntradasHuacales.Remove(entrada);
            await _context.SaveChangesAsync();
        }
    }
}
