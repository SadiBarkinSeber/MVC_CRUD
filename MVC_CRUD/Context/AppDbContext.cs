using MVC_CRUD.Models;
using Microsoft.EntityFrameworkCore;
namespace MVC_CRUD.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Student>().Property(x => x.Id).ValueGeneratedOnAdd();

            
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<School>().HasData(
                new School { Id = 1, Name = "Kadıköy Anadolu Lisesi", Address = "Kadıköy" },
                new School { Id = 2, Name = "Kartal Anadolu Lisesi", Address = "Kartal" },
                new School { Id = 3, Name = "Pendik Anadolu Lisesi", Address = "Pendik" }
            );

           
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Öğrenci 1", SchoolId = 1 },
                new Student { Id = 2, Name = "Öğrenci 2", SchoolId = 2 },
                new Student { Id = 3, Name = "Öğrenci 3", SchoolId = 3 }
            );
        }
    }
    
}
