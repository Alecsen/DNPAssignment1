using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class PostAppContext : DbContext
{
    public DbSet<AuthenticationUser> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/PostApp.db");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);            
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().HasKey(todo => todo.Id);
        modelBuilder.Entity<AuthenticationUser>().HasKey(user => user.Id);
    }
}