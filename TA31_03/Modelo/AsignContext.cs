using Microsoft.EntityFrameworkCore;

namespace TA31_03.Modelo
{
    public class AsignContext : DbContext
    {
        public AsignContext(DbContextOptions<AsignContext> options)
        : base(options)
        {
        }
        //Añadir AsignadoA
        public DbSet<AsignadoA> AsignadoAItems { get; set; } = null!;
    }
}
