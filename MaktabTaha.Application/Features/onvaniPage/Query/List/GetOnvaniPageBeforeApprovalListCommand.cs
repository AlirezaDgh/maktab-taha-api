using MaktabTaha.Application.DTO_s.onvaniPage.List;
using MaktabTaha.Application.DTO_s.onvaniPage.Search;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Query.List
{
    public class GetOnvaniPageBeforeApprovalListCommand : IRequest<OperationResult<List<OnvaniPageBeforeApprovalDTO>>>
    {
        public SearchOnvaniPageBeforeApprovalDTO Filters { get; set; }
    }
}
