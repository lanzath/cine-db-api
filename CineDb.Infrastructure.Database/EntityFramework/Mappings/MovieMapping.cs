using CineDb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CineDb.Infrastructure.Database.EntityFramework.Mappings;

public sealed class MovieMapping : IEntityTypeConfiguration<Movie>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable(nameof(Movie));
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Title).HasColumnType("TEXT").IsRequired();
        builder.Property(p => p.Year).HasColumnType("INTEGER");
        builder.Property(p => p.Genre)
            .HasConversion<int>()
            .HasColumnType("INTEGER");
        builder.Property(p => p.CreatedAt)
            .HasColumnType("TEXT")
            .HasDefaultValueSql("DATE('now')")
            .ValueGeneratedOnAdd();

        builder.HasOne(r => r.Director)
            .WithMany(r => r.Movies)
            .HasForeignKey(fk => fk.DirectorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}