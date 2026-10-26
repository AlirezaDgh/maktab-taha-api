using MaktabTaha.Application.DTO_s.donor.List;
using MaktabTaha.Application.DTO_s.donor.Search;
using MaktabTaha.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Interfaces.Repositories
{
    public interface IDonorRepository : IGenericRepository<int, Donor>
    {
        Task<List<DonorListDTO>> SearchDonorList(DonorSearchDTO filters);
    }
}
