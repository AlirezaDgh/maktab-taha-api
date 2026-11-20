using MaktabTaha.Application.DTO_s.caseDonorHelpsOnvani.List;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDonorHelpsOnvani.Query.List
{
    public class GetCaseDonorHelpsOnvaniListCommand : IRequest<OperationResult<List<CaseDonorHelpsOnvaniListDTO>>>
    {
        public int OnvaniId { get; set; }
    }
}
