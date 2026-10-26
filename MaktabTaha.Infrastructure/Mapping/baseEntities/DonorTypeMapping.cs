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
    public class DonorTypeMapping : IEntityTypeConfiguration<DonorType>
    {
        public void Configure(EntityTypeBuilder<DonorType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DonorTypeName);
        }
    }
}
