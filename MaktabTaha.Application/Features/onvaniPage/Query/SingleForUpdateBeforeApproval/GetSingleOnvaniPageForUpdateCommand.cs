using MaktabTaha.Application.DTO_s.onvaniPage.SingleForUpdate;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Query.SingleForUpdate
{
    public class GetSingleOnvaniPageForUpdateCommand : IRequest<OperationResult<SingleOnvaniPageForUpdateBeforeApprovalDTO>>
    {
        public int Id { get; set; }
    }
}
