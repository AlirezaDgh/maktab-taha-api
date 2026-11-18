using AutoMapper;
using MaktabTaha.Application.DTO_s.caseDonorHelps.List;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDonorHelps.Query.List
{
    public class GetCaseDonorHelpsListHandler : IRequestHandler<GetCaseDonorHelpsListCommand, OperationResult<List<CaseDonorHelpsListDTO>>>
    {
        private readonly ICaseDonorHelpsRepository _repository;
        private readonly IMapper _mapper;

        public GetCaseDonorHelpsListHandler(ICaseDonorHelpsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<CaseDonorHelpsListDTO>>> Handle(GetCaseDonorHelpsListCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<List<CaseDonorHelpsListDTO>>();
            var caseDonorHelps = await _repository.GetAllCaseHelps(request.caseNumber);

            var mappedData = _mapper.Map<List<CaseDonorHelpsListDTO>>(caseDonorHelps);
            return operation.Succedded(mappedData);
        }
    }
}
