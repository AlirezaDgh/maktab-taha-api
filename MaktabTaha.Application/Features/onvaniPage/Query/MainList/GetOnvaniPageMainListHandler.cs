using MaktabTaha.Application.DTO_s.onvaniPage.List;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Query.MainList
{
    public class GetOnvaniPageMainListHandler : IRequestHandler<GetOnvaniPageMainListCommand, OperationResult<OnvaniPageMainListDTO>>
    {
        
        public Task<OperationResult<OnvaniPageMainListDTO>> Handle(GetOnvaniPageMainListCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
