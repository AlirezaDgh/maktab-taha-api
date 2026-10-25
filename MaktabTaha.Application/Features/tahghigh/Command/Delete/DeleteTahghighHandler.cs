using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.tahghigh.Command.Delete
{
    public class DeleteTahghighHandler : IRequestHandler<DeleteTahghighCommand, OperationResult<bool>>
    {
        private readonly ITahghighRepository _repository;

        public DeleteTahghighHandler(ITahghighRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteTahghighCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<bool>();

            var tahghigh = await _repository.FirstOrDefault(x => x.Id == request.Id);
            if (tahghigh == null) return operation.Failure("تحقیق یافت نشد");

            await _repository.Delete(tahghigh);
            return operation.Succedded(true);
        }
    }
}
