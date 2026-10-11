using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Infrastructure.Mapping.casePerson
{
    public class CasePersonMapping : IEntityTypeConfiguration<CasePerson>
    {
        public void Configure(EntityTypeBuilder<CasePerson> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(x => x.CaseId);
            builder.HasOne(x => x.Case)
                .WithMany(x => x.CasePersons)
                .HasForeignKey(x => x.CaseId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Property(x => x.PersonId);
            builder.HasOne(x => x.Person)
                .WithMany(x => x.CasePersons)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Property(x => x.RelationId);
            builder.HasOne(x => x.Relation)
                .WithMany(x => x.CasePersons)
                .HasForeignKey(x => x.RelationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
