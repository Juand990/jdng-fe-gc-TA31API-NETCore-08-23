using Microsoft.EntityFrameworkCore;

namespace TA31_02.Modelo
{
    public class VideoContext : DbContext
    {
        public VideoContext(DbContextOptions<VideoContext> options)
        : base(options)
        {
        }

        //Añadir Video
        public DbSet<Video> VideoItems { get; set; } = null!;
    }
}
