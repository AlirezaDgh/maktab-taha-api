using MaktabTaha.Application.DTO_s.caseDesc.List;
using MaktabTaha.Application.DTO_s.caseDesc.Search;
using MaktabTaha.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Interfaces.Repositories
{
    public interface ICaseRepository : IGenericRepository<int, Case>
    {
        Task<List<CaseListDTO>> SearchCaseList(SearchCaseDTO filters);

        Task<Case> CreateNoSave(Case entity);

        Task<Case> GetByCaseNumberWithPersons(string caseNumber);


    }
}
