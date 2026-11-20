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
    public class GetCaseDonorHelpsTasvibListHandler : IRequestHandler<GetCaseDonorHelpsTasvibListCommand, OperationResult<List<CaseDonorHelpsTasvibListDTO>>>
    {
        private readonly ICaseDonorHelpsTasvibRepository _repository;
        private readonly IMapper _mapper;

        public GetCaseDonorHelpsTasvibListHandler(ICaseDonorHelpsTasvibRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<CaseDonorHelpsTasvibListDTO>>> Handle(GetCaseDonorHelpsTasvibListCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<List<CaseDonorHelpsTasvibListDTO>>();
            var caseDonorHelps = await _repository.GetAllCaseHelps(request.caseNumber);

            var mappedData = _mapper.Map<List<CaseDonorHelpsTasvibListDTO>>(caseDonorHelps);
            return operation.Succedded(mappedData);
        }
    }
}
