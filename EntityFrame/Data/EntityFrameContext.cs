using Microsoft.EntityFrameworkCore;

namespace EntityFrame.Data
{
    public class EntityFrameContext : DbContext
    {
        public EntityFrameContext(DbContextOptions<EntityFrameContext> options)
            : base(options)
        {
        }

        public DbSet<EntityFrame.Data.Entities.Person> People { get; set; } = default!;
    }
}
