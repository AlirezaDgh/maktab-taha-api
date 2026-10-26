using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.donor.Command.Update
{
    public class UpdateDonorCommand : IRequest<OperationResult<Donor>>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string ShenasnamehNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public int NationalityId { get; set; }
        public int GenderId { get; set; }
        public int MaritalStatusId { get; set; }
        public int ReligonId { get; set; }
        public string DonorType { get; set; }
        public int JobId { get; set; }
        public int EducationLevelId { get; set; }
        public int EducationStatusId { get; set; }
        public string EducationMajor { get; set; }
        public string MobileNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string JobPhoneNumber { get; set; }
        public int HouseProvinceId { get; set; }
        public int HouseCityId { get; set; }
        public string HomeAddress { get; set; }
        public string JobAddress { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int CharityMainRoleId { get; set; }
        public DateTime CharityJoinDate { get; set; }
        public int ReferrerId { get; set; }
        // نحوه آشنایی با خیریه
        public string CharityReferralSource { get; set; }
        // خدمات قابل ارائه
        public string AvailableServices { get; set; }
    }
}
