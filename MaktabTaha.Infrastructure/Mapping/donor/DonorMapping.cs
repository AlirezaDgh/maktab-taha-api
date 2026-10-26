using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Infrastructure.Mapping.donor
{
    public class DonorMapping : IEntityTypeConfiguration<Donor>

    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Firstname);
            builder.Property(x => x.Lastname);
            builder.Property(x => x.FatherName);
            builder.Property(x => x.NickName);
            builder.Property(x => x.NationalCode);
            builder.Property(x => x.ShenasnamehNumber);
            builder.Property(x => x.BirthDate);

            builder.Property(x => x.BirthProvinceId);
            builder.HasOne(x => x.BirthProvince)
                .WithMany()
                .HasForeignKey(x => x.BirthProvinceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.BirthCityId);
            builder.HasOne(x => x.BirthCity)
                .WithMany()
                .HasForeignKey(x => x.BirthCityId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Property(x => x.NationalityId);
            builder.HasOne(x => x.Nationality)
                .WithMany()
                .HasForeignKey(x => x.NationalityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.GenderId);
            builder.HasOne(x => x.Gender)
                .WithMany()
                .HasForeignKey(x => x.GenderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.MaritalStatusId);
            builder.HasOne(x => x.MaritalStatus)
                .WithMany()
                .HasForeignKey(x => x.MaritalStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.ReligonId);
            builder.HasOne(x => x.Religon)
                .WithMany()
                .HasForeignKey(x => x.ReligonId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.DonorTypeId);
            builder.HasOne(x => x.DonorType)
                .WithMany()
                .HasForeignKey(x => x.DonorTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.JobId);
            builder.HasOne(x => x.Job)
                .WithMany()
                .HasForeignKey(x => x.JobId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.EducationLevelId);
            builder.HasOne(x => x.EducationLevel)
                .WithMany()
                .HasForeignKey(x => x.EducationLevelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.EducationStatusId);
            builder.HasOne(x => x.EducationStatus)
                .WithMany()
                .HasForeignKey(x => x.EducationStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.EducationMajor);
            builder.Property(x => x.MobileNumber);
            builder.Property(x => x.HomePhoneNumber);
            builder.Property(x => x.JobPhoneNumber);

            builder.Property(x => x.HouseProvinceId);
            builder.HasOne(x => x.HouseProvince)
                .WithMany()
                .HasForeignKey(x => x.HouseProvinceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.HouseCityId);
            builder.HasOne(x => x.HouseCity)
                .WithMany()
                .HasForeignKey(x => x.HouseCityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.HomeAddress);
            builder.Property(x => x.JobAddress);
            builder.Property(x => x.Email);

            builder.Property(x => x.CharityMainRoleId);
            builder.HasOne(x => x.CharityMainRole)
                .WithMany()
                .HasForeignKey(x => x.CharityMainRoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.CharityJoinDate);

            builder.Property(x => x.ReferrerId);
            builder.HasOne(x => x.Referrer)
                .WithMany()
                .HasForeignKey(x => x.ReferrerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.CharityReferralSourceId);
            builder.HasOne(x => x.CharityReferralSource)
                .WithMany()
                .HasForeignKey(x => x.CharityReferralSourceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.AvailableServices);
        }
    }
}
