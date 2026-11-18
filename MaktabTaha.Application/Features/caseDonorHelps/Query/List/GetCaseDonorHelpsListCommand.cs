using MaktabTaha.Application.DTO_s.caseDonorHelps.List;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDonorHelps.Query.List
{
    public class GetCaseDonorHelpsListCommand : IRequest<OperationResult<List<CaseDonorHelpsListDTO>>>
    {
        public string caseNumber { get; set; }
    }
}
