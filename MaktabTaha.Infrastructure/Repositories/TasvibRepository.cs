using MaktabTaha.Application.DTO_s.tasvib.ListCaseOfTasvib;
using MaktabTaha.Application.DTO_s.tasvib.Search;
using MaktabTaha.Application.DTO_s.tasvib.TasvibDetails;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace MaktabTaha.Infrastructure.Repositories
{
    public class TasvibRepository : GenericRepository<int, Tasvib>, ITasvibRepository
    {
        private readonly ApplicationDbContext _context;
        public TasvibRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tasvib> FirstOrDefaultWith(string caseNumber)
        {
            return await _context.Tasvib
                .Include(x => x.Case)
                .FirstOrDefaultAsync(x => x.CaseNumber == caseNumber);
        }


        // اطلاعات جزئیات تصویب
        public async Task<TasvibDetailsDTO> GetTasvibDetails(int id)
        {
            return await _context.Tasvib
                .Where(x => x.Id == id)
                .AsNoTracking()
                .Select(x => new TasvibDetailsDTO
                {
                    Id = id,
                    TasvibDate = x.TasvibDate,
                    CaseNumber = x.CaseNumber,
                    ClientRequestDescription = x.ClientRequestDescription,
                    TasvibStatusId = x.TasvibStatusId,
                    TasvibStatusName = x.TasvibStatus.Title,
                    TasvibReason = x.TasvibReason,
                    Description = x.Description,
                    ManagerTasvibStatusId = x.ManagerTasvibStatusId,
                    ManagerTasvibStatusName = x.ManagerTasvibStatus.Title,

                    CaseDonorHelpDetails = x.CaseDonorHelpsTasvib.Select(x => new CaseDonorHelpDetailsDTO
                    {
                        RequestTypeId = x.RequestTypeId,
                        RequestTypeName = x.RequestType.RequestTypeName,
                        MoneyAmount = x.MoneyAmount,
                        DonorId = x.DonorId,
                        DonorFullName = x.Donor.Firstname + " " + x.Donor.Lastname,
                        FromDate = x.FromDate,
                        ToDate = x.ToDate,
                    }).ToList(),


                    CaseDonorHelpSummary = x.CaseDonorHelpsTasvib.GroupBy(x => x.RequestTypeId)
                    .Select(y => new CaseDonorHelpSummaryDTO
                    {
                        RequestTypeId = y.Key,
                        RequestTypeName = y.First().RequestType.RequestTypeName,
                        TotalMoneyAmount = y.Sum(x => x.MoneyAmount),
                        FromDate = y.Min(x => x.FromDate),
                        ToDate = y.Max(x => x.ToDate),
                    }).ToList()

                }).FirstOrDefaultAsync();
        }




        public async Task<List<ListCaseOfTasvibDTO>> SearchCaseOfTasvibList(SearchCaseOfTasvibDTO filters)
        {
            // لیست پرونده های تصویب

            var query = _context.Tasvib
                .Where(x => x.Case.CaseStageId == 4)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(filters.CaseNumber))
            {
                var caseNumber = filters.CaseNumber.Trim();
                query = query.Where(x => x.CaseNumber != null &&
                                    x.CaseNumber.Contains(caseNumber));
            }

            if (!string.IsNullOrWhiteSpace(filters.SupervisorFirstName))
            {
                var firstName = filters.SupervisorFirstName.Trim();
                query = query.Where(x => x.Case.CasePersons
                                                    .Any(x => x.Person.FirstName != null &&
                                                         x.RelationId == 1 &&
                                                         x.Person.FirstName.Contains(firstName)));
            }

            if (!string.IsNullOrWhiteSpace(filters.SupervisorLastName))
            {
                var lastName = filters.SupervisorLastName.Trim();
                query = query.Where(x => x.Case.CasePersons
                                            .Any(x => x.Person.LastName != null &&
                                                 x.RelationId == 1 &&
                                                 x.Person.LastName.Contains(lastName)));
            }

            return await query
                            .OrderByDescending(x => x.CreatedDate)
                            .Select(x => new ListCaseOfTasvibDTO
                            {
                                Id = x.Id,
                                TasvibDate = x.TasvibDate,
                                CaseNumber = x.CaseNumber,

                                SupervisorFirstName = x.Case.CasePersons
                                                                    .Where(x => x.RelationId == 1)
                                                                    .Select(x => x.Person.FirstName)
                                                                    .FirstOrDefault(),

                                SupervisorLastName = x.Case.CasePersons
                                                                    .Where(x => x.RelationId == 1)
                                                                    .Select(x => x.Person.LastName)
                                                                    .FirstOrDefault(),

                                TasvibStatusId = x.TasvibStatusId,
                                TasvibStatusName = x.TasvibStatus.Title,
                                ManagerTasvibStatusId = x.ManagerTasvibStatusId,
                                ManagerTasvibStatusName = x.ManagerTasvibStatus.Title

                            }).ToListAsync();

        }
    }
}
