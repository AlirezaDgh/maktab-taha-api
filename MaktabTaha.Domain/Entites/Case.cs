using MaktabTaha.Domain.Common;
using MaktabTaha.Domain.Entites.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites
{
    public class Case : BaseEntity<int>
    {
        //آیدی پرونده و تاریخ ثبت پرونده در BaseEntity وجود دارند
        // شماره پرونده
        public string CaseNumber { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }
        public int CaseTypeId { get; set; }
        public CaseType CaseType { get; set; }
        public int PrivatenessStatusId { get; set; }
        public PrivatenessStatus PrivatenessStatus { get; set; }
        public int HouseHeadStatusId { get; set; }
        public HouseHeadStatus HouseHeadStatus { get; set; }
        public int ReferrerId { get; set; }
        public Donor Referrer { get; set; }

        //اطلاعات سکونت
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string AddressDesc { get; set; }
        public string PostalCode { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }

        //آدرس در نقشه
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeNumber { get; set; }

        // اطلاعات مالی 
        public string AccountName { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
        public string BankBranchName { get; set; }
        public string BankBranchCode { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
        public string CardNumber { get; set; }
        public List<Attachments> Attachments { get; set; } = new List<Attachments>();

        // اعضای تحت تکفل یا سرپرست
        [JsonIgnore]
        public List<CasePerson> CasePersons { get; set; } = new List<CasePerson>();

        // مرحله پرونده
        public int CaseStageId { get; set; }
        public CaseStage CaseStage { get; set; }

        // وضعیت فعال
        public CaseActiveStatus ActiveStatus { get; set; }
        public List<Moshavereh> Moshaverehs { get; set; } = new List<Moshavereh>();
    }
}
