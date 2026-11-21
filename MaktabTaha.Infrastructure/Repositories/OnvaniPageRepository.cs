using MaktabTaha.Application.DTO_s.onvaniPage.List;
using MaktabTaha.Application.DTO_s.onvaniPage.Search;
using MaktabTaha.Application.DTO_s.onvaniPage.Single;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MaktabTaha.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Infrastructure.Repositories
{
    public class OnvaniPageRepository : GenericRepository<int, OnvaniPage>, IOnvaniPageRepository
    {
        private readonly ApplicationDbContext _context;
        public OnvaniPageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SingleOnvaniPageDTO> GetOnvaniPageDetails(int id)
        {
            return await _context.OnvaniPage
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new SingleOnvaniPageDTO
                {
                    Id = id,
                    RequestDate = x.RequestDate,
                    CaseNumber = x.CaseNumber,
                    FirstName = x.Case.CasePersons.Where(x => x.RelationId == 1).Select(x => x.Person.FirstName).FirstOrDefault(),
                    LastName = x.Case.CasePersons.Where(x => x.RelationId == 1).Select(x => x.Person.LastName).FirstOrDefault(),
                    RequestTypeId = x.RequestTypeId,
                    ReuqestTypeName = x.RequestType.RequestTypeName,
                    HelpMoney = x.HelpMoney,
                    CreateDescription = x.CreateDescription,
                    MoshaverIdea = x.MoshaverIdea,
                    HeadOfWorkingGroupId = x.HeadOfWorkingGroupId,
                    HeadOfWorkingGroupName = x.HeadOfWorkingGroup.Firstname + x.HeadOfWorkingGroup.Lastname,
                    MoshaverId = x.MoshaverId,
                    MoshaverName = x.Moshaver.Firstname + x.Moshaver.Lastname
                }).FirstOrDefaultAsync();
        }


        public async Task<List<OnvaniPageBeforeApprovalDTO>> GetOnvaniPagesBeforeApprovalSearch(SearchOnvaniPageBeforeApprovalDTO Filters)
        {
            var query = _context.OnvaniPage
                .Where(x => x.TasvibStatusId == 1)
                .AsNoTracking();

            if (Filters.Id.HasValue)
            {
                query = query.Where(x => x.Id == Filters.Id.Value);
            }

            if (!string.IsNullOrWhiteSpace(Filters.CaseNumber))
            {
                var caseNumber = Filters.CaseNumber.Trim();
                query = query.Where(x => x.CaseNumber != null &&
                                    x.CaseNumber.Contains(caseNumber));
            }

            if (Filters.FromDate.HasValue)
            {
                var fromDate = Filters.FromDate.Value.Date;
                query = query.Where(x => x.RequestDate >= fromDate);
            }

            if (Filters.ToDate.HasValue)
            {
                var toDate = Filters.ToDate.Value.Date.AddDays(1);
                query = query.Where(x => x.RequestDate < toDate);
            }

            return await query
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new OnvaniPageBeforeApprovalDTO
                {
                    Id = x.Id,
                    RequestDate = x.RequestDate,
                    CaseNumber = x.CaseNumber,
                    RequestTypeId = x.RequestTypeId,
                    RequestTypeName = x.RequestType.RequestTypeName,
                    MoshaverId = x.MoshaverId,
                    MoshaverName = x.Moshaver.Firstname + x.Moshaver.Lastname
                }).ToListAsync();
        }

        public async Task<List<OnvaniPageBeforeManagerAcceptDTO>> GetOnvaniPagesBeforeManagerAcceptSearch(SearchOnvaniPageBeforeManagerAcceptDTO Filters)
        {
            var query = _context.OnvaniPage
                .Where(x => x.ManagerTasvibStatusId == 1)
                .AsNoTracking();

            if (Filters.Id.HasValue)
            {
                query = query.Where(x => x.Id == Filters.Id.Value);
            }

            if (!string.IsNullOrWhiteSpace(Filters.CaseNumber))
            {
                var caseNumber = Filters.CaseNumber.Trim();
                query = query.Where(x => x.CaseNumber != null &&
                                    x.CaseNumber.Contains(caseNumber));
            }

            if (Filters.FromDate.HasValue)
            {
                var fromDate = Filters.FromDate.Value.Date;
                query = query.Where(x => x.RequestDate >= fromDate);
            }

            if (Filters.ToDate.HasValue)
            {
                var toDate = Filters.ToDate.Value.Date.AddDays(1);
                query = query.Where(x => x.RequestDate < toDate);
            }

            return await query
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new OnvaniPageBeforeManagerAcceptDTO
                {
                    Id = x.Id,
                    RequestDate = x.RequestDate,
                    CaseNumber = x.CaseNumber,
                    RequestTypeId = x.RequestTypeId,
                    RequestTypeName = x.RequestType.RequestTypeName,
                    MoshaverId = x.MoshaverId,
                    MoshaverName = x.Moshaver.Firstname + x.Moshaver.Lastname
                }).ToListAsync();
        }



        public async Task<OnvaniPageMainListDTO> GetOnvaniPageMainList(string CaseNumber)
        {
            return await (
                from c in _context.CaseBNF.AsNoTracking()
                where c.CaseNumber == CaseNumber

                let Supervisor = c.CasePersons.Where(x => x.RelationId == 1).Select(x => x.Person)

                select (new OnvaniPageMainListDTO
                {
                    CaseNumber = CaseNumber,
                    SupervisorFirstName = Supervisor.Select(x => x.FirstName).FirstOrDefault(),
                    SupervisorLastName = Supervisor.Select(x => x.LastName).FirstOrDefault(),
                    PrivatenessStatusId = c.PrivatenessStatusId,
                    PrivatenessStatusName = c.PrivatenessStatus.PrivatenessStatusName,
                    HouseHeadStatusId = c.HouseHeadStatusId,
                    HouseHeadStatusName = c.HouseHeadStatus.Name,
                    CaseStageId = c.CaseStageId,
                    CaseStageDesc = c.CaseStage.CaseStageDesc,

                    ApprovedOnvaniPageDTOs = c.OnvaniPages.Where(x => x.TasvibStatusId.HasValue).Select(x => new ApprovedOnvaniPageDTO
                    {
                        Id = x.Id,
                        RequestDate = x.RequestDate,
                        CaseNumber = x.CaseNumber,
                        ClientRequestDescription = x.CreateDescription,
                    }).ToList(),

                    CaseDonorHelpsOnvaniDTOs = c.OnvaniPages.Where(x => x.TasvibStatusId.HasValue).SelectMany(x => x.CaseDonorHelpsOnvani)
                                                                    .Select(x => new CaseDonorHelpsOnvaniDTO
                                                                    {
                                                                        RequestTypeId = x.RequestTypeId,
                                                                        RequestTypeName = x.RequestType.RequestTypeName,
                                                                        MoneyAmount = x.MoneyAmount,
                                                                        FromDate = x.FromDate,
                                                                        ToDate = x.ToDate
                                                                    }).ToList(),

                    CaseDonorHelpsOnvaniSummaryDTOs = c.OnvaniPages.Where(x => x.TasvibStatusId.HasValue).SelectMany(x => x.CaseDonorHelpsOnvani)
                                .GroupBy(x => new
                                {
                                    x.RequestTypeId
                                })
                                .Select(y => new CaseDonorHelpsOnvaniSummaryDTO
                                {
                                    RequestTypeId = y.Key.RequestTypeId,
                                    RequestTypeName = y.First().RequestType.RequestTypeName,
                                    TotalMoneyAmount = y.Sum(x => x.MoneyAmount),
                                    FromDate = y.First().FromDate,
                                    ToDate = y.First().ToDate
                                }).ToList()


                })
                ).FirstOrDefaultAsync();
        }
    }
}
