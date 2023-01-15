using Microsoft.EntityFrameworkCore;
using ProiectVisual.Models;

namespace ProiectVisual.Data
{
    public class Context : DbContext
    {
        public DbSet<Member> Members {get; set;}
        public DbSet<Job> Jobs {get; set;}

        public Context(DbContextOptions<Context> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
