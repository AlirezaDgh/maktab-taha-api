using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaktabTaha.Infrastructure.Mapping.permission
{
    public class PermissionMapping : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Key)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Path)
                .HasMaxLength(300);

            builder.Property(x => x.Icon)
                .HasMaxLength(100);

            builder.Property(x => x.SortOrder)
                .IsRequired();

            // Self Reference
            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique Key
            builder.HasIndex(x => x.Key)
                .IsUnique();


        }
    }
}
