using MaktabTaha.Domain.Common;
using MaktabTaha.Domain.Entites.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites
{
    public class Request : BaseEntity<int>
    {
        public DateTime RequestDate { get; set; }
        public string RequestDescription { get; set; }

        public int RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }

        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }

        public int HouseHeadStatusId { get; set; }
        public HouseHeadStatus HouseHeadStatus { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public int RefererId { get; set; }
        public Donor Referer { get; set; }

        public int NationaltyId { get; set; }
        public Nationality Nationalty { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string HomeNumber { get; set; }

        public int AreaId { get; set; }
        public Area Area { get; set; }

        public int ReligonId { get; set; }
        public Religon Religon { get; set; }

        // Approve
        public int RequestStatusId { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public string? StatusReason { get; set; }
        public DateTime? ApproveDate { get; set; }
        public string? OfficerDescription { get; set; }
        public byte[]? Attachment { get; set; }

    }
}
