using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Infrastructure.Mapping.tahghigh
{
    public class TahghighMapping : IEntityTypeConfiguration<Tahghigh>
    {
        public void Configure(EntityTypeBuilder<Tahghigh> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TahghighDate);

            builder.Property(x => x.MoshaverehId);
            builder.HasOne(x => x.Moshavereh)
                .WithMany()
                .HasForeignKey(x => x.MoshaverehId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.ClientDescription);

            builder.Property(x => x.FirstMohagheghCode);

            builder.Property(x => x.SecondMohagheghCode);

            // enum نظر محقق
            builder.Property(x => x.MohagheghIdea).HasConversion<string>();

            builder.Property(x => x.MohagheghDescription);
        }
    }
}
