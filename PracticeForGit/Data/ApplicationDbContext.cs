using Microsoft.EntityFrameworkCore;
using PracticeForGit.Models;

namespace PracticeForGit.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure optional relationship: Employee -> Department (FK = DepartmentId)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany() // if you later add a collection on Department (e.g. ICollection<Employee> Employees) change this
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}