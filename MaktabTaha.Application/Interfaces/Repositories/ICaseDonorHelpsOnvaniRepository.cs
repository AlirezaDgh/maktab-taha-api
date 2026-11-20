using MaktabTaha.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Interfaces.Repositories
{
    public interface ICaseDonorHelpsOnvaniRepository : IGenericRepository<int, CaseDonorHelpsOnvani>
    {
        Task<List<CaseDonorHelpsOnvani>> GetAllCaseHelpsOnvani(int id);

    }
}
