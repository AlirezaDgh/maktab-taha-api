using AutoMapper;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.tahghigh.Command.Create
{
    public class CreateTahghighHandler : IRequestHandler<CreateTahghighCommand, OperationResult<Tahghigh>>
    {
        private readonly ITahghighRepository _tahghighRepository;
        private readonly IMapper _mapper;
        private readonly ICaseRepository _caseRepository;

        public CreateTahghighHandler(ITahghighRepository tahghighRepository, IMapper mapper, ICaseRepository caseRepository)
        {
            _tahghighRepository = tahghighRepository;
            _mapper = mapper;
            _caseRepository = caseRepository;
        }

        public async Task<OperationResult<Tahghigh>> Handle(CreateTahghighCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<Tahghigh>();
            var caseBnf = await _caseRepository.SingleOrDefault(x => x.Moshaverehs.Any(x => x.Id == request.MoshaverehId));
            if (caseBnf.CaseStageId != 2) return operation.Failure("ثبت تحقیق قبلا انجام شده است"); 

            var mappedData = _mapper.Map<Tahghigh>(request);

            await _tahghighRepository.Create(mappedData);
            caseBnf.CaseStageId = 3;
            await _caseRepository.SaveChanges();
            return operation.Succedded(mappedData);
        }
    }
}
