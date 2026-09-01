using ChoreTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ChoreTracker.Data
{
    public class ChoreDbContext : DbContext
    {
        public ChoreDbContext(DbContextOptions<ChoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Chore> Chores { get; set; }
    }
}
