using MaktabTaha.Application.DTO_s.onvaniPage.List;
using MaktabTaha.Application.DTO_s.onvaniPage.Search;
using MaktabTaha.Application.Helpers;
using MediatR;

namespace MaktabTaha.Application.Features.onvaniPage.Query.ListBeforeManagerAccept
{
    public class GetOnvaniPageListBeforeManagerAcceptCommand : IRequest<OperationResult<List<OnvaniPageBeforeManagerAcceptDTO>>>
    {
        public SearchOnvaniPageBeforeManagerAcceptDTO Filters { get; set; }
    }
}
