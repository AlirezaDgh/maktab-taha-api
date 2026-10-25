using MaktabTaha.Application.DTO_s.tahghigh.List;
using MaktabTaha.Application.DTO_s.tahghigh.Search;
using MaktabTaha.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Interfaces.Repositories
{
    public interface ITahghighRepository : IGenericRepository<int, Tahghigh>
    {
        Task<Tahghigh> FirstOrDefaultWith(string caseNumber);
        Task<List<TahghighListDTO>> GetAllTahghighList(SearchTahghighDTO filters);
    }
}
