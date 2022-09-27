using Microsoft.EntityFrameworkCore;

namespace APIPerfumes
{
    public class PerfumeContext: DbContext
    {
        public PerfumeContext(DbContextOptions<PerfumeContext> opt): base(opt)
        {
        }

        public DbSet<Perfume> Perfumes { get; set; }
    }
}
