using Microsoft.EntityFrameworkCore;
using Cristian_TavarezAPI1_P1.Models;

namespace Cristian_TavarezAPI1_P1.Contexto;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<EntradaHuacales> EntradasHuacales { get; set; }
}



