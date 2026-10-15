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

namespace MaktabTaha.Application.Features.caseDesc.Command.Update
{
    public class UpdateCaseHandler : IRequestHandler<UpdateCaseCommand, OperationResult<Case>>
    {
        private readonly ICaseRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCaseHandler(ICaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<Case>> Handle(UpdateCaseCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<Case>();

            var caseDesc = await _repository.FirstOrDefault(x => x.CaseNumber ==  request.CaseNumber);
            if (caseDesc == null) return operation.Failure("یافت نشد");

            _mapper.Map(request, caseDesc);
            caseDesc.UpdatedDate = DateTime.Now;
            _repository.Update(caseDesc);
            return operation.Succedded(caseDesc);
        }
    }
}
