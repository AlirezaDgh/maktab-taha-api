using MaktabTaha.Application.DTO_s.caseDesc.Single;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDesc.Query.SingleCaseMoshavereh
{
    public class GetSingleCaseMoshaverehCommand : IRequest<OperationResult<CaseMoshaverehSingleDTO>>
    {
        public string CaseNumber { get; set; }
    }
}
