using MaktabTaha.Application.Features.baseEntities.donorType.Query.List;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories.BaseEntities;
using MaktabTaha.Domain.Entites.BaseEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.baseEntities.donorType.Query.List
{
    public class GetDonorTypeListHandler : IRequestHandler<GetDonorTypeListCommand, OperationResult<List<DonorType>>>
    {
        private readonly IDonorTypeRepository _repository;

        public GetDonorTypeListHandler(IDonorTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<List<DonorType>>> Handle(GetDonorTypeListCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<List<DonorType>>();

            var DonorTypes = await _repository.List();
            return operation.Succedded(DonorTypes);
        }
    }
}
