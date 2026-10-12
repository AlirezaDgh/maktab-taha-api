using MaktabTaha.Application.DTO_s.Moshavereh.List;
using MaktabTaha.Application.DTO_s.Moshavereh.Search;
using MaktabTaha.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Interfaces.Repositories
{
    public interface IMoshaverehRepository : IGenericRepository<int, Moshavereh>
    {
        Task<List<MoshaverehListDTO>> SearchMoshaverehList(MoshaverehSearchDTO filters);
        Task<Moshavereh> GetWithAttach(int id);
        Task<Moshavereh> FirstOrDefaultWith(string caseNumber);
    }
}
