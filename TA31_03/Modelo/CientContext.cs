using Microsoft.EntityFrameworkCore;
using TA31_03.Modelo;

namespace TA31_03.Modelo
{
    public class CientContext : DbContext
    {
        public CientContext(DbContextOptions<CientContext> options)
        : base(options)
        {
        }

        //Añadir Cientificos
        public DbSet<Cientificos> CientificosItems { get; set; } = null!;

    }
}
