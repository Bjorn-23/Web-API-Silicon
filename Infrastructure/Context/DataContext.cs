
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<SubscriptionEntity> Subscriptions { get; set; }

    public DbSet<CourseEntity> Courses { get; set; }

    public DbSet<ContactEntity> Contacts { get; set; }

    public DbSet<CategoryEntity> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SubscriptionEntity>()
            .HasIndex(e => e.Email)
            .IsUnique();

        modelBuilder.Entity<ContactEntity>()
            .HasKey(e => e.Id);
    }
}
