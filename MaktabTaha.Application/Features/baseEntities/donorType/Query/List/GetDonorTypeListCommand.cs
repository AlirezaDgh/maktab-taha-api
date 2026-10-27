using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites.BaseEntities;
using MediatR;

namespace MaktabTaha.Application.Features.baseEntities.donorType.Query.List
{
    public class GetDonorTypeListCommand : IRequest<OperationResult<List<DonorType>>>
    {
    }
}
