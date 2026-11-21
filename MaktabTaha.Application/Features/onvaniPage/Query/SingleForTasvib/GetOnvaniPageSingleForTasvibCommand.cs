using MaktabTaha.Application.DTO_s.onvaniPage.SingleForTasvib;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Query.SingleForTasvib
{
    public class GetOnvaniPageSingleForTasvibCommand : IRequest<OperationResult<OnvaniPageSingleForTasvibDTO>>
    {
        public int Id { get; set; }
    }
}
