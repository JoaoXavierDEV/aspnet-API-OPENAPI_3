using HeavyApps.Blog.Domain.Model;
using HeavyApps.Blog.Infrastructure.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HeavyApps.Blog.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
{
    public BlogDbContext CreateDbContext(string[] args)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables()
                .AddUserSecrets<BlogDbContext>()
                .Build();

        var optionsBuilder = new DbContextOptionsBuilder();

        optionsBuilder
            .UseSqlite(@"DataSource=app.db;Cache=Shared")
            .UseSeeding((context, _) =>
            {
                context.Set<Autor>().AddRange(DbInitializer.Autores);
                context.SaveChanges();
            })
            .EnableSensitiveDataLogging()
            //.UseLazyLoadingProxies()
            .LogTo(Console.WriteLine, LogLevel.Error);
        //.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted }, LogLevel.Information, DbContextLoggerOptions.LocalTime | DbContextLoggerOptions.SingleLine);;

        return new BlogDbContext(optionsBuilder.Options);
    }
}



/*

// criar primeira migração
dotnet ef migrations add InitialCreate --project C:\Projetos\net\HeavyApps\src\HeavyApps.Blog.Infrastructure\HeavyApps.Blog.Infrastructure.csproj --context "HeavyApps.Blog.Infrastructure.Data.DataContext.BlogDbContext" --output-dir Data/Migrations

// criar migração com outro nome
dotnet ef migrations add ImplementarLike --project C:\Projetos\net\HeavyApps\src\HeavyApps.Blog.Infrastructure\HeavyApps.Blog.Infrastructure.csproj --context "HeavyApps.Blog.Infrastructure.Data.DataContext.BlogDbContext" --output-dir Data/Migrations

// atualizar o banco com a nova migração
dotnet ef database update --project C:\Projetos\net\HeavyApps\src\HeavyApps.Blog.Infrastructure\HeavyApps.Blog.Infrastructure.csproj --context "HeavyApps.Blog.Infrastructure.Data.DataContext.BlogDbContext"


*/