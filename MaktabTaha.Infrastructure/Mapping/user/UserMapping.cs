using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaktabTaha.Infrastructure.Mapping.user
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Mobile)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.PasswordHash)
                .HasMaxLength(500);

            builder.HasIndex(x => x.UserName)
                 .IsUnique();

            builder.HasIndex(x => x.Mobile)
                 .IsUnique();

            // User -> Role
            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
