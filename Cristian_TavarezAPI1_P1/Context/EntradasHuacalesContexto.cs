using Microsoft.EntityFrameworkCore;
using Cristian_TavarezAPI1_P1.Models;

namespace Cristian_TavarezAPI1_P1.Contexto;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<EntradaHuacales> EntradasHuacales { get; set; }
    public DbSet<TipoHuacal> TiposHuacales { get; set; }
    public DbSet<EntradaHuacalDetalle> EntradasHuacalesDetalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EntradaHuacalDetalle>()
            .HasOne(d => d.Entrada)
            .WithMany(e => e.Detalles)
            .HasForeignKey(d => d.EntradaId);

        modelBuilder.Entity<EntradaHuacalDetalle>()
            .HasOne(d => d.TipoHuacal)
            .WithMany(t => t.Detalles)
            .HasForeignKey(d => d.TipoId);

        modelBuilder.Entity<TipoHuacal>().HasData(
       new TipoHuacal { TipoId = 1, Descripcion = "Rojo", Existencia = 0 },
       new TipoHuacal { TipoId = 2, Descripcion = "Verde", Existencia = 0 }
       );
    }
}



