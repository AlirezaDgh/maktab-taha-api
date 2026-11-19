using AutoMapper;
using MaktabTaha.Application.DTO_s.onvaniPage.SingleForUpdate;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Query.SingleForUpdate
{
    public class GetSingleOnvaniPageForUpdateHandler : IRequestHandler<GetSingleOnvaniPageForUpdateCommand, OperationResult<SingleOnvaniPageForUpdateBeforeApprovalDTO>>
    {
        // جزئیات برای ویرایش
        private readonly IOnvaniPageRepository _repository;
        private readonly IMapper _mapper;

        public GetSingleOnvaniPageForUpdateHandler(IOnvaniPageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<SingleOnvaniPageForUpdateBeforeApprovalDTO>> Handle(GetSingleOnvaniPageForUpdateCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<SingleOnvaniPageForUpdateBeforeApprovalDTO>();

            var onvaniPage = await _repository.FirstOrDefault(x => x.Id == request.Id);
            if (onvaniPage == null) return operation.Failure("برگه عنوانی یافت نشد");

            var mappedData = _mapper.Map<SingleOnvaniPageForUpdateBeforeApprovalDTO>(onvaniPage);
            return operation.Succedded(mappedData);
        }
    }
}
