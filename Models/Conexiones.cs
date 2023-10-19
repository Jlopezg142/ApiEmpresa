using Microsoft.EntityFrameworkCore;
using ApiEmpresa.models;
namespace ApiEmpresa.models;
public class Conexiones : DbContext
{
    public Conexiones(DbContextOptions<Conexiones> options)
        : base(options) {
    }

    public DbSet<Clientes> Clientes { get; set; } = null!;

    public DbSet<Puestos> Puestos { get; set; } = default!;

}