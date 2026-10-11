using AutoMapper;
using MaktabTaha.Application.DTO_s.caseDesc.Single;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDesc.Query.Single
{
    public class GetSingleCaseHandler : IRequestHandler<GetSingleCaseCommand, OperationResult<CaseSingleDTO>>
    {
        private readonly ICaseRepository _repository;
        private readonly IMapper _mapper;

        public GetSingleCaseHandler(ICaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<CaseSingleDTO>> Handle(GetSingleCaseCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<CaseSingleDTO>();

            var caseDesc = await _repository.FirstOrDefault(x => x.CaseNumber == request.CaseNumber);
            if (caseDesc == null)
                return operation.Failure("یافت نشد");

            var mappedData = _mapper.Map<CaseSingleDTO>(caseDesc);
            return operation.Succedded(mappedData);
        }
    }
}
