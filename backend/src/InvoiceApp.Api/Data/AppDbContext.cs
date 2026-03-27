using Microsoft.EntityFrameworkCore;
using InvoiceApp.Api.Models.Entities;

namespace InvoiceApp.Api.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
    public DbSet<InvoiceTemplateSettings> InvoiceTemplateSettings { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User configuration

        modelBuilder.Entity<User>(entity => 
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Email).IsRequired().HasMaxLength(256);
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);  
        });

        // Client configuration
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.BusinessName).IsRequired().HasMaxLength(200);
            entity.HasOne(e => e.User)
                .WithMany(u => u.Clients)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasQueryFilter(e => !e.IsDeleted);
        });


        // Invoice configuration
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.InvoiceNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Subtotal).HasPrecision(18, 2);
            entity.Property(e => e.TaxRate).HasPrecision(5, 2);
            entity.Property(e => e.TaxAmount).HasPrecision(18, 2);
            entity.Property(e => e.DiscountPercent).HasPrecision(5, 2);
            entity.Property(e => e.DiscountAmount).HasPrecision(18, 2);
            entity.Property(e => e.Total).HasPrecision(18, 2);

            entity.HasOne(e => e.User)
                .WithMany(u => u.Invoices)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Client)
                .WithMany(c => c.Invoices)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasQueryFilter(e => !e.IsDeleted);
            // Add an index on UserId, Type, and Status for faster querying
            entity.HasIndex(e => new { e.UserId, e.Type, e.Status});

            // Line items configuration
            modelBuilder.Entity<InvoiceLineItem>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Quantity).HasPrecision(18, 2);
                entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
                entity.Property(e => e.LineTotal).HasPrecision(18, 2);
                entity.HasOne(e => e.Invoice)
                    .WithMany(i => i.LineItems)
                    .HasForeignKey(e => e.InvoiceId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        });

        // Template settings — one per user
        modelBuilder.Entity<InvoiceTemplateSettings>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.User)
                  .WithOne(u => u.InvoiceTemplateSettings)
                  .HasForeignKey<InvoiceTemplateSettings>(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Refresh tokens
        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Token).IsRequired();
            entity.HasIndex(e => e.Token).IsUnique();
            entity.HasOne(e => e.User)
                  .WithMany(u => u.RefreshTokens)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

    }
}