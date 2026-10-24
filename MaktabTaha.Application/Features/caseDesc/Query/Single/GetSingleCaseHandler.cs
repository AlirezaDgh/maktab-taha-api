using AutoMapper;
using MaktabTaha.Application.DTO_s.caseDesc.Single;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDesc.Query.Single
{
    public class GetSingleCaseHandler : IRequestHandler<GetSingleCaseCommand, OperationResult<CaseSingleDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICaseRepository _repository;

        public GetSingleCaseHandler(IMapper mapper, ICaseRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<OperationResult<CaseSingleDTO>> Handle(GetSingleCaseCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<CaseSingleDTO>();

            var caseBnf = await _repository.FirstOrDefault(x => x.Id == request.Id);
            if (caseBnf == null) return operation.Failure("پرونده یافت نشد");

            var mappedData = _mapper.Map<CaseSingleDTO>(caseBnf);
            return operation.Succedded(mappedData);
        }
    }
}
