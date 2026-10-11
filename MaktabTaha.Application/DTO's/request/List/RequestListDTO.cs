using System;

namespace MaktabTaha.Application.DTO_s.Requests.List
{
    public class RequestListDTO
    {
        public int Id { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? RequestDescription { get; set; }

        // Request
        public int RequestTypeId { get; set; }

        public string? RequestTypeTitle { get; set; }

        // Client
        public string? ClientFirstName { get; set; }

        public string? ClientLastName { get; set; }

        public string FullName =>
            $"{ClientFirstName} {ClientLastName}".Trim();

        public int HouseHeadStatusId { get; set; }

        public string? HouseHeadStatusTitle { get; set; }

        public int? GenderId { get; set; }
        public string? GenderTitle { get; set; }

        public int RefererId { get; set; }

        public string? RefererName { get; set; }

        public int NationaltyId { get; set; }

        public string? NationaltyTitle { get; set; }

        // Location
        public int ProvinceId { get; set; }

        public string? ProvinceTitle { get; set; }

        public int CityId { get; set; }

        public string? CityTitle { get; set; }

        public int AreaId { get; set; }

        public string? AreaTitle { get; set; }

        public string? Address { get; set; }

        // Contact
        public string? MobileNumber { get; set; }

        public string? HomeNumber { get; set; }

        // Religion
        public int ReligonId { get; set; }

        public string? ReligonTitle { get; set; }

        // Status
        public int RequestStatusId { get; set; }

        public string? RequestStatusTitle { get; set; }

        public string? StatusReason { get; set; }

        public DateTime? ApproveDate { get; set; }

        public string? OfficerDescription { get; set; }

        public byte[]? Attachment { get; set; }
    }
}