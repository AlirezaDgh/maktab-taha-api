using AutoMapper;
using MaktabTaha.Application.DTO_s.donor.List;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.donor.Query.List
{
    public class GetDonorListHandler : IRequestHandler<GetDonorListCommand, OperationResult<List<DonorListDTO>>>
    {
        private readonly IDonorRepository _repository;

        public GetDonorListHandler(IDonorRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<List<DonorListDTO>>> Handle(GetDonorListCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<List<DonorListDTO>>();

            var Donors = await _repository.SearchDonorList(request.Filters);
            return operation.Succedded(Donors);
        }
    }
}
