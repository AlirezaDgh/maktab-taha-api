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
    public class GetSingleCaseMoshaverehHandler : IRequestHandler<GetSingleCaseMoshaverehCommand, OperationResult<CaseMoshaverehSingleDTO>>
    {
        private readonly ICaseRepository _repository;
        private readonly IMapper _mapper;

        public GetSingleCaseMoshaverehHandler(ICaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<CaseMoshaverehSingleDTO>> Handle(GetSingleCaseMoshaverehCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<CaseMoshaverehSingleDTO>();

            var caseDesc = await _repository.FirstOrDefault(x => x.CaseNumber == request.CaseNumber);
            if (caseDesc == null)
                return operation.Failure("یافت نشد");

            var supervisor = caseDesc.CasePersons.FirstOrDefault(x => x.Relation.Id == 1).Person;

            var caseDto = new CaseMoshaverehSingleDTO
            {
                SupervisorFirstName = supervisor.FirstName,
                SupervisorLsatName = supervisor.LastName,
                HouseHeadStatusId = caseDesc.HouseHeadStatusId,
                CaseStageId = caseDesc.CaseStageId

            };

            return operation.Succedded(caseDto);
        }
    }
}
