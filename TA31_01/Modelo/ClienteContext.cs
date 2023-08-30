using Microsoft.EntityFrameworkCore;

namespace TA31_01.Modelo
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options)
        : base(options)
        {
        }
        //Añadir Cliente
        public DbSet<Cliente> ClienteItems { get; set; } = null!;
    }
}
