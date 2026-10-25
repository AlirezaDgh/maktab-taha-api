using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Infrastructure.Mapping.attachment
{
    public class AttachmentMapping : IEntityTypeConfiguration<Attachments>
    {
        public void Configure(EntityTypeBuilder<Attachments> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AttachmentType);
            builder.Property(x => x.Attach);

            builder.Property(x => x.PersonId);
            builder.HasOne(x => x.Person)
                .WithMany()
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.CaseId);
            builder.HasOne(x => x.Case)
                .WithMany()
                .HasForeignKey(x => x.CaseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.TahghighId);
            builder.HasOne(x => x.Tahghigh)
                .WithMany()
                .HasForeignKey(x => x.TahghighId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
