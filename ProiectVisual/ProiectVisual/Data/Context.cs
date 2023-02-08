using Microsoft.EntityFrameworkCore;
using ProiectVisual.Models;

namespace ProiectVisual.Data
{
    public class Context : DbContext
    {
        public DbSet<Member> Members {get; set;}
        public DbSet<Job> Jobs {get; set;}
        public DbSet<Department> Departments {get; set;}
        public DbSet<Event> Events {get; set;}
        public DbSet<User> Users {get; set;}



        public Context(DbContextOptions<Context> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent api
            //One to Many
            modelBuilder.Entity<Department>()
                .HasMany(dp => dp.Members)
                .WithOne(mb => mb.Department)
                .HasForeignKey(mb => mb.DepartmentId);
                 


            //Many to Many
            //Cheie compusa
            modelBuilder.Entity<ModelsRelation>()
                .HasKey(mr => new {mr.MemberId, mr.JobId});

            modelBuilder.Entity<ModelsRelation>()
                .HasOne<Member>(mr=>mr.Member)
                .WithMany(mb => mb.ModelsRelation)
                .HasForeignKey(mr=>mr.MemberId);

            modelBuilder.Entity<ModelsRelation>()
                .HasOne<Job>(mr => mr.Job)
                .WithMany(jb => jb.ModelsRelation)
                .HasForeignKey(mr => mr.JobId);

            //One to One
            modelBuilder.Entity<Department>()
                .HasOne(dp => dp.Event)
                .WithOne(ev => ev.Department)
                .HasForeignKey<Event>(ev => ev.DepartmentId);

              

            base.OnModelCreating(modelBuilder);
        }
    }
}
