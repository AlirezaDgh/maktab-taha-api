using MaktabTaha.Application.DTO_s.Requests.List;
using MaktabTaha.Application.DTO_s.Requests.Search;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace MaktabTaha.Infrastructure.Repositories
{
    public class RequestRepository
        : GenericRepository<int, Request>, IRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<RequestListDTO>> SearchRequest(
            SearchRequestListDTO entity)
        {
            var query = _context.Request
                .AsNoTracking()
                .AsQueryable();

            // شماره درخواست
            if (entity.RequestId.HasValue)
            {
                query = query.Where(x =>
                    x.Id == entity.RequestId.Value);
            }

            // نام
            if (!string.IsNullOrWhiteSpace(entity.ClientFirstName))
            {
                var firstName = entity.ClientFirstName.Trim();

                query = query.Where(x =>
                    x.ClientFirstName != null &&
                    x.ClientFirstName.Contains(firstName));
            }

            // نام خانوادگی
            if (!string.IsNullOrWhiteSpace(entity.ClientLastName))
            {
                var lastName = entity.ClientLastName.Trim();

                query = query.Where(x =>
                    x.ClientLastName != null &&
                    x.ClientLastName.Contains(lastName));
            }

            // انواع درخواست
            if (entity.RequestTypeIds is { Count: > 0 })
            {
                query = query.Where(x =>
                    entity.RequestTypeIds.Contains(x.RequestTypeId));
            }

            // وضعیت درخواست
            if (entity.RequestStatusId.HasValue)
            {
                query = query.Where(x =>
                    x.RequestStatusId == entity.RequestStatusId.Value);
            }

            // تاریخ از
            if (entity.FromDate.HasValue)
            {
                var fromDate = entity.FromDate.Value.Date;

                query = query.Where(x =>
                    x.CreatedDate >= fromDate);
            }

            // تاریخ تا
            if (entity.ToDate.HasValue)
            {
                var toDate = entity.ToDate.Value.Date.AddDays(1);

                query = query.Where(x =>
                    x.CreatedDate < toDate);
            }

            return await query
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new RequestListDTO
                {
                    Id = x.Id,

                    RequestDate = x.RequestDate,

                    CreatedDate = x.CreatedDate,

                    RequestDescription =
                        x.RequestDescription ?? string.Empty,

                    RequestTypeId = x.RequestTypeId,

                    ClientFirstName =
                        x.ClientFirstName ?? string.Empty,

                    ClientLastName =
                        x.ClientLastName ?? string.Empty,

                    HouseHeadStatusId =
                        x.HouseHeadStatusId,

                    GenderId = x.GenderId,

                    GenderTitle =
                        x.Gender.GenderName ?? string.Empty,

                    RefererId =
                        x.RefererId,

                    NationaltyId =
                        x.NationaltyId,

                    ProvinceId =
                        x.ProvinceId,

                    ProvinceTitle =
                        x.Province.ProvinceName,

                    CityId =
                        x.CityId,

                    CityTitle =
                        x.City.CityName,


                    Address =
                        x.Address ?? string.Empty,

                    MobileNumber =
                        x.MobileNumber ?? string.Empty,

                    HomeNumber =
                        x.HomeNumber ?? string.Empty,

                    AreaId =
                        x.AreaId,

                    AreaTitle =
                        x.Area.AreaName,


                    ReligonId =
                        x.ReligonId,

                    RequestTypeTitle =
                        x.Religon.ReligonName,


                    RequestStatusId =
                        x.RequestStatusId,

                    RequestStatusTitle =
                        x.RequestStatus.RequestStatusName,


                    StatusReason =
                        x.StatusReason ?? string.Empty,

                    OfficerDescription =
                        x.OfficerDescription ?? string.Empty,

                    ApproveDate =
                        null,

                    Attachment =
                        x.Attachment
                })
                .ToListAsync();
        }
    }
}