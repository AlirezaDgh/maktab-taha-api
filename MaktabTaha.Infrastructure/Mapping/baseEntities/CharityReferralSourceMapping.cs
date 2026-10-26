using MaktabTaha.Domain.Entites.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Infrastructure.Mapping.baseEntities
{
    public class CharityReferralSourceMapping : IEntityTypeConfiguration<CharityReferralSource>
    {
        public void Configure(EntityTypeBuilder<CharityReferralSource> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CharityReferralSourceName);
        }
    }
}
