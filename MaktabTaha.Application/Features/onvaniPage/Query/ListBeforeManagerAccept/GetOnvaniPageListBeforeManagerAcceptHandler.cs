using AutoMapper;
using MaktabTaha.Application.DTO_s.onvaniPage.List;
using MaktabTaha.Application.DTO_s.onvaniPage.Search;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace MaktabTaha.Application.Features.onvaniPage.Query.ListBeforeManagerAccept
{
    public class GetOnvaniPageListBeforeManagerAcceptHandler : IRequestHandler<GetOnvaniPageListBeforeManagerAcceptCommand, OperationResult<List<OnvaniPageBeforeManagerAcceptDTO>>>
    {
        private readonly IOnvaniPageRepository _repository;

        public GetOnvaniPageListBeforeManagerAcceptHandler(IOnvaniPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<List<OnvaniPageBeforeManagerAcceptDTO>>> Handle(GetOnvaniPageListBeforeManagerAcceptCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<List<OnvaniPageBeforeManagerAcceptDTO>>();
            var onvaniPages = await _repository.GetOnvaniPagesBeforeManagerAcceptSearch(request.Filters);

            return operation.Succedded(onvaniPages);
        }
    }
}
