using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.onvaniPage.List
{
    public class OnvaniPageMainListDTO
    {

    }

    public class CaseOnvaniPageListHeaderDTO
    {
        public string SupervisorFirstName { get; set; }
        public string SupervisorLastName { get; set; }
        public int PrivatenessStatusId { get; set; }
        public string PrivatenessStatusName { get; set; }
        public int HouseHeadStatusId { get; set; }
        public string HouseHeadStatusName { get; set; }
        public int CaseStageId { get; set; }
        public string CaseStageDesc { get; set; }
    }

    public class ApprovedOnvaniPageDTO
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string CaseNumber { get; set; }
        public string ClientRequestDescription { get; set; }

    }

    //public class CaseDonorHelps
}
