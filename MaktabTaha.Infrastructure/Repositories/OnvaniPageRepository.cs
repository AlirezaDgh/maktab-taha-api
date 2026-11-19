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
                    RequestDate = x.RequestDate,
                    CaseNumber = x.CaseNumber,
                    RequestTypeId = x.RequestTypeId,
                    RequestTypeName = x.RequestType.RequestTypeName,
                    MoshaverId = x.MoshaverId,
                    MoshaverName = x.Moshaver.Firstname + x.Moshaver.Lastname
                }).ToListAsync();
        }
    }
}
