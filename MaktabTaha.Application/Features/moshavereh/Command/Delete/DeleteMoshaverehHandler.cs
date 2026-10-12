using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.moshavereh.Command.Delete
{
    public class DeleteMoshaverehHandler : IRequestHandler<DeleteMoshaverehCommand, OperationResult<bool>>
    {
        private readonly IMoshaverehRepository _repository;

        public DeleteMoshaverehHandler(IMoshaverehRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteMoshaverehCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<bool>();

            var moshavereh = await _repository.FirstOrDefault(x => x.Id == request.Id);
            if (moshavereh == null) return operation.Failure("پیش تحقیق یافت نشد");

            await _repository.Delete(moshavereh);
            return operation.Succedded(true);
        }
    }
}
