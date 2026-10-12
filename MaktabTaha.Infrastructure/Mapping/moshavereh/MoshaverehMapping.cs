using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Infrastructure.Mapping.moshavereh
{
    public class MoshaverehMapping : IEntityTypeConfiguration<Moshavereh>
    {
        public void Configure(EntityTypeBuilder<Moshavereh> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CaseNumber);
            builder.HasOne(x => x.Case)
                .WithMany(x => x.Moshaverehs)
                .HasForeignKey(x => x.CaseNumber)
                .HasPrincipalKey(x => x.CaseNumber)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.ClientRequestDescription);

            builder.Property(X => X.MoshaverCode);

            builder.Property(x => x.MoshaverIdea);
            builder.Property(x => x.MoshaverExplaination);
        }
    }
}
