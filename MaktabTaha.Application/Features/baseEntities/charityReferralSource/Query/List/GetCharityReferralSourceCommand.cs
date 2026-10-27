using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites.BaseEntities;
using MediatR;

namespace MaktabTaha.Application.Features.baseEntities.charityReferralSource.Query.List
{
    public class GetCharityReferralSourceListCommand : IRequest<OperationResult<List<CharityReferralSource>>>
    {
    }
}
