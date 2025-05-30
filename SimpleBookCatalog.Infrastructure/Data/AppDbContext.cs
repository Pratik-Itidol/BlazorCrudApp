namespace SimpleBookCatalog.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Domain.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_id");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .HasColumnName("author");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.CreatedAtDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at_date");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("'Pratik'::text")
                .HasColumnName("created_by");
            entity.Property(e => e.PublicationDate).HasColumnName("publicationDate");
            entity.Property(e => e.RemovedAt).HasColumnName("removed_at");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAtDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("updated_at_date");
            entity.Property(e => e.UpdatedBy)
                .HasDefaultValueSql("'Pratik'::text")
                .HasColumnName("updated_by");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
