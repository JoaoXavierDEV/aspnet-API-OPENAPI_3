using Microsoft.EntityFrameworkCore;
using OpenAPI3.Api.Models;

namespace OpenAPI3.Api.Data;

//public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Post> Posts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Autor)
            .WithMany(a => a.Posts)
            .HasForeignKey(p => p.AutorID);

        modelBuilder.Entity<Autor>()
            .HasMany(p => p.Posts)
            .WithOne(a => a.Autor);

        base.OnModelCreating(modelBuilder);
    }
}
