using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CineDb.Infrastructure.Database.EntityFramework;

public sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    AppDbContext IDesignTimeDbContextFactory<AppDbContext>.CreateDbContext(string[] args)
    {
        // Configure and return an instance of the AppDbContext for design-time operations
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=../CineDb.Infrastructure.Database/Database.sqlite");

        return new AppDbContext(optionsBuilder.Options);
    }
}