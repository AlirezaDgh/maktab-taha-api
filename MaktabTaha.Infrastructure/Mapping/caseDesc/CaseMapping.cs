using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Infrastructure.Mapping.caseDesc
{
    public class CaseMapping : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate);

            builder.Property(x => x.CaseNumber);
            builder.HasAlternateKey(x => x.CaseNumber);

            builder.Property(x => x.RequestId);
            builder.HasOne(x => x.Request)
                .WithOne()
                .HasForeignKey<Case>(x => x.RequestId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.CaseTypeId);
            builder.HasOne(x => x.CaseType)
                .WithMany()
                .HasForeignKey(x => x.CaseTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.PrivatenessStatusId);
            builder.HasOne(x => x.PrivatenessStatus)
                .WithMany()
                .HasForeignKey(x => x.PrivatenessStatusId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.HouseHeadStatusId);
            builder.HasOne(x => x.HouseHeadStatus)
                .WithMany()
                .HasForeignKey(x => x.HouseHeadStatusId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.ReferrerId);
            builder.HasOne(x => x.Referrer)
                .WithMany()
                .HasForeignKey(x => x.ReferrerId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Property(x => x.CityId);
            builder.HasOne(x => x.City)
                .WithMany()
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.ProvinceId);
            builder.HasOne(x => x.Province)
                .WithMany()
                .HasForeignKey(x => x.ProvinceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.AddressDesc);
            builder.Property(x => x.PostalCode);

            builder.Property(x => x.AreaId);
            builder.HasOne(x => x.Area)
                .WithMany()
                .HasForeignKey(x => x.AreaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Latitude);
            builder.Property(x => x.Longitude);
            builder.Property(x => x.HomeNumber);
            builder.Property(x => x.PhoneNumber);

            builder.Property(x => x.AccountName);

            builder.Property(x => x.BankId);
            builder.HasOne(x => x.Bank)
                .WithMany()
                .HasForeignKey(x => x.BankId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.BankBranchName);
            builder.Property(x => x.BankBranchCode);
            builder.Property(x => x.AccountNumber);
            builder.Property(x => x.IBAN);
            builder.Property(x => x.CardNumber);

            builder.Property(x => x.CaseStageId);
            builder.HasOne(x => x.CaseStage)
                .WithMany()
                .HasForeignKey(x => x.CaseStageId)
                .OnDelete(DeleteBehavior.Cascade);

            // enum وضعیت فعال بودن
            builder.Property(x => x.ActiveStatus).HasConversion<string>();
            

        }
    }
}
