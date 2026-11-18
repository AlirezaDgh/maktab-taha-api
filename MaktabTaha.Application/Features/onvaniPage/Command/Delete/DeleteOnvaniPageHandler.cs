using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Command.Delete
{
    public class DeleteOnvaniPageHandler : IRequestHandler<DeleteOnvaniPageCommand, OperationResult<bool>>
    {
        private readonly IOnvaniPageRepository _onvaniPageRepository;

        public DeleteOnvaniPageHandler(IOnvaniPageRepository onvaniPageRepository)
        {
            _onvaniPageRepository = onvaniPageRepository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteOnvaniPageCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<bool>();

            var onvaniPage = await _onvaniPageRepository.FirstOrDefault(x => x.Id == request.Id);
            if (onvaniPage == null) return operation.Failure("برگه عنوانی یافت نشد");

            await _onvaniPageRepository.Delete(onvaniPage);
            return operation.Succedded(true);
        }
    }
}
