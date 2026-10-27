using MaktabTaha.Application.DTO_s.donor.Single;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.donor.Query.Single
{
    public class GetSingleDonorCommand : IRequest<OperationResult<DonorSingleDTO>>
    {
        public int Id { get; set; }
    }
}
