using Microsoft.EntityFrameworkCore;
using RR.ToDo.Domain.Models;

namespace RR.ToDo.Infra.Contexts;

public class EntityContext : DbContext
{
    public DbSet<TaskModel> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=todo.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskModel>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<TaskModel>()
            .Property(p => p.Status)
            .HasConversion<int>();
    }
}
