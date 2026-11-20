using MaktabTaha.Application.DTO_s.caseDonorHelps.List;
using MaktabTaha.Application.DTO_s.tasvib.TasvibDetails;
using MaktabTaha.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Interfaces.Repositories
{
    public interface ICaseDonorHelpsTasvibRepository : IGenericRepository<int, CaseDonorHelpsTasvib>
    {
        Task<List<CaseDonorHelpsTasvib>> GetAllCaseHelps(string caseNumber);
    }
}
