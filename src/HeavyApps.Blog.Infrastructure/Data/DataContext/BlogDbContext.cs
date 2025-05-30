using HeavyApps.Blog.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HeavyApps.Blog.Infrastructure.Data.DataContext
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                         .SelectMany((e) => e.GetProperties()
                             .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=app.db;Cache=Shared")
                .EnableSensitiveDataLogging()
            //.UseLazyLoadingProxies()
            .LogTo(Console.WriteLine, LogLevel.Error);
            //.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted }, LogLevel.Information, DbContextLoggerOptions.LocalTime | DbContextLoggerOptions.SingleLine);
            ;
        }


        public DbSet<Post> Posts { get; set; }
        public DbSet<Autor> Autores { get; set; }
    }


}
