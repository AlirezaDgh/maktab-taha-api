using MaktabTaha.Application.DTO_s.onvaniPage.Single;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Query.Single
{
    public class GetSingleOnvaniPageHandler : IRequestHandler<GetSingleOnvaniPageCommand, OperationResult<SingleOnvaniPageDTO>>
    {
        // نمایش جزئیات

        private readonly IOnvaniPageRepository _repository;

        public GetSingleOnvaniPageHandler(IOnvaniPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<SingleOnvaniPageDTO>> Handle(GetSingleOnvaniPageCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<SingleOnvaniPageDTO>();
            var onvaniPage = await _repository.GetOnvaniPageDetails(request.Id);
            if (onvaniPage == null) return operation.Failure("برگه عنوانی یافت نشد");

            return operation.Succedded(onvaniPage);
        }
    }
}
