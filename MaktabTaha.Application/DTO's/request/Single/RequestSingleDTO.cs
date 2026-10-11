using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.Requests.Single
{
    public class RequestSingleDTO
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestDescription { get; set; }

        public int RequestTypeId { get; set; }

        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }

        public int HouseHeadStatusId { get; set; }

        public int GenderId { get; set; }
        public int RefererId { get; set; }

        public int NationaltyId { get; set; }

        public int ProvinceId { get; set; }
        public int CityId { get; set; }

        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string HomeNumber { get; set; }

        public int AreaId { get; set; }

        public int ReligonId { get; set; }

        //Approve
        public int RequestStatusId { get; set; }
        public string StatusReason { get; set; }
        public DateTime ApproveDate { get; set; }
        public string OfficerDescription { get; set; }
        public byte[] Attachment { get; set; }
    }
}
