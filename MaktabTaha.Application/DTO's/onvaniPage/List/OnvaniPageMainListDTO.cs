using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.onvaniPage.List
{
    public class OnvaniPageMainListDTO
    {
        // هدر اطلاعات
        public string CaseNumber { get; set; }
        public string SupervisorFirstName { get; set; }
        public string SupervisorLastName { get; set; }
        public int PrivatenessStatusId { get; set; }
        public string PrivatenessStatusName { get; set; }
        public int HouseHeadStatusId { get; set; }
        public string HouseHeadStatusName { get; set; }
        public int CaseStageId { get; set; }
        public string CaseStageDesc { get; set; }
        
        // سایر اطلاعات
        public List<ApprovedOnvaniPageDTO>? ApprovedOnvaniPageDTOs { get; set; } = new List<ApprovedOnvaniPageDTO>();
        public List<CaseDonorHelpsOnvaniDTO>? CaseDonorHelpsOnvaniDTOs { get; set; } = new List<CaseDonorHelpsOnvaniDTO>();
        public List<CaseDonorHelpsOnvaniSummaryDTO>? CaseDonorHelpsOnvaniSummaryDTOs { get; set; } = new List<CaseDonorHelpsOnvaniSummaryDTO>();
    }

    public class ApprovedOnvaniPageDTO
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string CaseNumber { get; set; }
        public string ClientRequestDescription { get; set; }

    }

    public class CaseDonorHelpsOnvaniDTO
    {
        public int RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
        public decimal MoneyAmount { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class CaseDonorHelpsOnvaniSummaryDTO
    {
        public int RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
        public decimal TotalMoneyAmount { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
