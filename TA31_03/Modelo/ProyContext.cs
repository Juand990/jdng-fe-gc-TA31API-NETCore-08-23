using Microsoft.EntityFrameworkCore;

namespace TA31_03.Modelo
{
    public class ProyContext : DbContext
    {
        public ProyContext(DbContextOptions<ProyContext> options)
        : base(options)
        {
        }

        //Añadir Proyectos
        public DbSet<Proyectos> ProyectosItems { get; set; } = null!;
    }
}
