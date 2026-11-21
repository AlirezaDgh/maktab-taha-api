using MaktabTaha.Application.DTO_s.onvaniPage.List;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
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
        private readonly IOnvaniPageRepository _repository;

        public GetOnvaniPageMainListHandler(IOnvaniPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<OnvaniPageMainListDTO>> Handle(GetOnvaniPageMainListCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<OnvaniPageMainListDTO>();
            var onvaniPageList = await _repository.GetOnvaniPageMainList(request.CaseNumber);
            if (onvaniPageList == null) return operation.Failure("این پرونده یافت نشد");

            return operation.Succedded(onvaniPageList);
        }
    }
}
