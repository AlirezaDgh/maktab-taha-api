using AutoMapper;
using MaktabTaha.Application.DTO_s.caseDesc.Single;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDesc.Query.SingleCaseMoshavereh
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

            try
            {
                var caseDesc = await _repository.GetCaseMoshaverehSingle(request.CaseNumber);

                if (caseDesc == null) return operation.Failure("پرونده یافت نشد");

                return operation.Succedded(caseDesc);

            }
            catch (Exception ex)
            {
                return operation.Failure(ex.Message);
            }
        }
    }
}
