using AutoMapper;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.moshavereh.Command.Create
{
    public class CreateMoshaverehcHandler : IRequestHandler<CreateMoshaverehcCommand, OperationResult<Moshavereh>>
    {
        private readonly IMoshaverehRepository _repository;
        private readonly ICaseRepository _caseRepository;
        private readonly IMapper _mapper;

        public CreateMoshaverehcHandler(IMoshaverehRepository repository, IMapper mapper, ICaseRepository caseRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _caseRepository = caseRepository;
        }

        public async Task<OperationResult<Moshavereh>> Handle(CreateMoshaverehcCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<Moshavereh>();

            var caseDesc = await _caseRepository.FirstOrDefault(x => x.CaseNumber == request.CaseNumber);
            if (caseDesc == null) return operation.Failure("پرونده وجود ندارد");

            if (caseDesc.CaseStageId == 2) return operation.Failure("ثبت مشاوره قبلا انجام شده است");

            var mappedData = _mapper.Map<Moshavereh>(request);

            await _repository.Create(mappedData); 

            return operation.Succedded(mappedData);

        }
    }
}
