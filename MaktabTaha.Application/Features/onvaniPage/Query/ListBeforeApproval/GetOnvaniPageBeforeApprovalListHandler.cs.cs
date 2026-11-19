using MaktabTaha.Application.DTO_s.onvaniPage.List;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;

namespace MaktabTaha.Application.Features.onvaniPage.Query.List
{
    public class GetOnvaniPageBeforeApprovalListHandler : IRequestHandler<GetOnvaniPageBeforeApprovalListCommand, OperationResult<List<OnvaniPageBeforeApprovalDTO>>>
    {
        private readonly IOnvaniPageRepository _repository;

        public GetOnvaniPageBeforeApprovalListHandler(IOnvaniPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<List<OnvaniPageBeforeApprovalDTO>>> Handle(GetOnvaniPageBeforeApprovalListCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<List<OnvaniPageBeforeApprovalDTO>>();
            var onvaniPages = await _repository.GetOnvaniPagesBeforeApprovalSearch(request.Filters);

            return operation.Succedded(onvaniPages);
        }
    }
}
