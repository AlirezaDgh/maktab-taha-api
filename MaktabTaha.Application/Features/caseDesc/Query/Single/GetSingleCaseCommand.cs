using MaktabTaha.Application.DTO_s.caseDesc.Single;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDesc.Query.Single
{
    public class GetSingleCaseCommand : IRequest<OperationResult<CaseSingleDTO>>
    {
        public int Id { get; set; }
    }
}
