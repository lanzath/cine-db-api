using CineDb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CineDb.Infrastructure.Database.EntityFramework.Mappings;

public sealed class DirectorMapping : IEntityTypeConfiguration<Director>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Director> builder)
    {
        builder.ToTable(nameof(Director));
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Name).HasColumnType("TEXT");
        builder.Property(p => p.OriginCountry).HasColumnType("TEXT");
        builder.Property(p => p.Age).HasColumnType("INTEGER");
        builder.Property(p => p.CreatedAt)
            .HasColumnType("TEXT")
            .HasDefaultValueSql("DATE('now')")
            .ValueGeneratedOnAdd();
    }
}