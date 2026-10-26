using MaktabTaha.Application.DTO_s.donor.List;
using MaktabTaha.Application.DTO_s.donor.Search;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.donor.Query.List
{
    public class GetDonorListCommand : IRequest<OperationResult<List<DonorListDTO>>>
    {
        public DonorSearchDTO Filters { get; set; }
    }
}
