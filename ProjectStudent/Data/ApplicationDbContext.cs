using Microsoft.EntityFrameworkCore;
using ProjectStudent.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProjectStudent.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasCheckConstraint("CHK_IsraeliID", "IsraeliID NOT LIKE '%[^0-9]%' AND LEN(IsraeliID) = 9");
        }
    }
}
