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

namespace MaktabTaha.Application.Features.donor.Command.Delete
{
    public class DeleteDonorHandler : IRequestHandler<DeleteDonorCommand, OperationResult<bool>>
    {
        private readonly IDonorRepository _repository;
        private readonly IMapper _mapper;

        public DeleteDonorHandler(IDonorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<bool>> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<bool>();

            var donor = await _repository.FirstOrDefault(x => x.Id == request.Id);
            if (donor == null) return operation.Failure("خیر یافت نشد");

            await _repository.Delete(donor);
            return operation.Succedded(true);
        }
    }
}
