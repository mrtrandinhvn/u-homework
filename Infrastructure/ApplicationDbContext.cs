using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Website.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductPrizeDrawSubmission> ProductPrizeDrawSubmissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Overwrite Aspnet Identity tables due to a known issue with Id length: https://github.com/aspnet/Identity/issues/1451
        modelBuilder.Entity<IdentityUser>().Property(x => x.Id).HasMaxLength(225);
        modelBuilder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(225);
        modelBuilder.Entity<IdentityUserLogin<string>>().Property(x => x.ProviderKey).HasMaxLength(225);
        modelBuilder.Entity<IdentityUserLogin<string>>().Property(x => x.LoginProvider).HasMaxLength(225);
        modelBuilder.Entity<IdentityUserToken<string>>().Property(x => x.Name).HasMaxLength(112);
        modelBuilder.Entity<IdentityUserToken<string>>().Property(x => x.LoginProvider).HasMaxLength(112);

        // configure custom tables
        modelBuilder.Entity<Product>().ToTable("Product", "dbo")
            .HasKey(x => x.SerialNumber);
        modelBuilder.Entity<Product>().HasMany(x => x.PrizeSubmissions)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductSerialNumber);

        modelBuilder.Entity<ProductPrizeDrawSubmission>().ToTable("ProductPrizeDrawSubmission", "dbo");
    }
}
