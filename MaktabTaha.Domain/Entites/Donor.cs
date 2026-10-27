using MaktabTaha.Domain.Common;
using MaktabTaha.Domain.Entites.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites
{
    public class Donor : BaseEntity<int>
    {
        // جدول خیرین و معرف و محقق
        public string Firstname { get; set; }
        public string Lastname { get; set; } 
        public string FatherName { get; set; }
        public string NickName { get; set; }
        public string NationalCode { get; set; }
        public string ShenasnamehNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int BirthProvinceId { get; set; }
        public Province BirthProvince { get; set; }
        public int BirthCityId { get; set; }
        public City BirthCity { get; set; }
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int MaritalStatusId { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Religon Religon { get; set; }
        public int ReligonId { get; set; }
        public int DonorTypeId { get; set; }
        public DonorType DonorType { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public int EducationStatusId { get; set; }
        public EducationStatus EducationStatus { get; set; }
        public string EducationMajor { get; set; }
        public string MobileNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string JobPhoneNumber { get; set; }
        public int HouseProvinceId { get; set; }
        public Province HouseProvince { get; set; }
        public int HouseCityId { get; set; }
        public City HouseCity { get; set; }
        public string HomeAddress { get; set; }
        public string JobAddress { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int CharityMainRoleId { get; set; }
        public CharityMainRole CharityMainRole { get; set; }
        public DateTime CharityJoinDate { get; set; }
        public int? ReferrerId { get; set; }
        public Donor? Referrer { get; set; }
        // نحوه آشنایی با خیریه
        public int CharityReferralSourceId { get; set; }
        public CharityReferralSource CharityReferralSource { get; set; }
        // خدمات قابل ارائه
        public string AvailableServices { get; set; }
    }

}
