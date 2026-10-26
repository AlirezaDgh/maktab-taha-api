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

namespace MaktabTaha.Application.Features.donor.Command.Update
{
    public class UpdateDonorHandler : IRequestHandler<UpdateDonorCommand, OperationResult<Donor>>
    {
        private readonly IDonorRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDonorHandler(IDonorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<Donor>> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<Donor>();
            var donor = await _repository.FirstOrDefault(x => x.Id == request.Id);
            if (donor == null) return operation.Failure("خیر یافت نشد");

            _mapper.Map(request, donor);
            donor.UpdatedDate = DateTime.Now;
            await _repository.Update(donor);

            return operation.Succedded(donor);
        }
    }
}
