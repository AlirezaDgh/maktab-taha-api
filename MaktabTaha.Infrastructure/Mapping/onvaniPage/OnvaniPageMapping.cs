using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Infrastructure.Mapping.onvaniPage
{
    public class OnvaniPageMapping : IEntityTypeConfiguration<OnvaniPage>
    {
        public void Configure(EntityTypeBuilder<OnvaniPage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RequestDate);

            builder.Property(x => x.CaseNumber);
            builder.HasOne(x => x.Case)
                .WithMany(x => x.OnvaniPages)
                .HasForeignKey(x => x.CaseNumber)
                .HasPrincipalKey(x => x.CaseNumber)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.RequestTypeId);
            builder.HasOne(x => x.RequestType)
                .WithOne()
                .HasForeignKey<OnvaniPage>(x => x.RequestTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.HelpMoney);
            builder.Property(x => x.CreateDescription);
            builder.Property(x => x.MoshaverIdea);

            builder.Property(x => x.HeadOfWorkingGroupId);
            builder.HasOne(x => x.HeadOfWorkingGroup)
                .WithMany()
                .HasForeignKey(x => x.HeadOfWorkingGroupId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.MoshaverId);
            builder.HasOne(x => x.Moshaver)
                .WithMany()
                .HasForeignKey(x => x.MoshaverId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.TasvibStatusId).HasDefaultValue(1);
            builder.HasOne(x => x.TasvibStatus)
                .WithMany()
                .HasForeignKey(x => x.TasvibStatusId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.TasvibReason);

            builder.Property(x => x.ManagerTasvibStatusId).HasDefaultValue(1);
            builder.HasOne(x => x.ManagerTasvibStatus)
                .WithMany()
                .HasForeignKey(x => x.ManagerTasvibStatusId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.CreateDescription);


        }
    }
}
