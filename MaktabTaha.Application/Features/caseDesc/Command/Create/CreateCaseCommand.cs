using MaktabTaha.Application.DTO_s.casePerson.Create;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MaktabTaha.Domain.Entites.BaseEntities;
using MediatR;

namespace MaktabTaha.Application.Features.caseDesc.Command.Create
{
    public class CreateCaseCommand : IRequest<OperationResult<Case>>
    {
        public string CaseNumber { get; set; }

        public int RequestId { get; set; }
        public int CaseTypeId { get; set; }
        public int PrivatenessStatusId { get; set; }
        public int HouseHeadStatusId { get; set; }
        public int ReferrerId { get; set; }

        //اطلاعات سکونت
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string AddressDesc { get; set; }
        public string PostalCode { get; set; }
        public int AreaId { get; set; }

        //آدرس در نقشه
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeNumber { get; set; }

        // اطلاعات مالی 
        public string AccountName { get; set; }
        public int BankId { get; set; }
        public string BankBranchName { get; set; }
        public string BankBranchCode { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
        public string CardNumber { get; set; }

        // مرحله پرونده
        public int CaseStageId { get; set; }

        // وضعیت فعال
        public CaseActiveStatus ActiveStatus { get; set; }



        public List<CreateCasePersonDTO> PersonsInCase { get; set; } = new List<CreateCasePersonDTO>();
    }
}
