using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDesc.Command.Delete
{
    public class DeleteCaseHandler : IRequestHandler<DeleteCaseCommand, OperationResult<bool>>
    {
        private readonly ICaseRepository _repository;

        public DeleteCaseHandler(ICaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteCaseCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<bool>();

            var caseDesc = await _repository.FirstOrDefault(x => x.CaseNumber == request.CaseNumber);
            if (caseDesc == null) return operation.Failure("یافت نشد");

            await _repository.Delete(caseDesc);
            return operation.Succedded(true);
        }
    }
}
