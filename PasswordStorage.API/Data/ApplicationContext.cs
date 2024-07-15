using Microsoft.EntityFrameworkCore;
using PasswordStorage.API.Models;

namespace PasswordStorage.API.Data;

public class ApplicationContext : DbContext
{
    public DbSet<UserPassword> UserPasswords { get; set; } = null!;
    public DbSet<WebsitePassword> WebsitePasswords { get; set; } = null!;
    public DbSet<EmailPassword> EmailPasswords { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<WebsitePassword>(typeBuilder => typeBuilder
            .Property(p => p.Url)
            .HasConversion<string>());
        builder.Entity<EmailPassword>(typeBuilder => typeBuilder
            .Property(p => p.Email)
            .HasMaxLength(320));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase(databaseName: "PasswordStorage");
    }
}