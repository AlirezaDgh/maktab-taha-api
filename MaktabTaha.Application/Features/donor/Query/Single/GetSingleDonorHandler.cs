using AutoMapper;
using MaktabTaha.Application.DTO_s.donor.Single;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.donor.Query.Single
{
    public class GetSingleDonorHandler : IRequestHandler<GetSingleDonorCommand, OperationResult<DonorSingleDTO>>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IMapper _mapper;

        public GetSingleDonorHandler(IDonorRepository donorRepository, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<DonorSingleDTO>> Handle(GetSingleDonorCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<DonorSingleDTO>();

            var donor = await _donorRepository.FirstOrDefault(x => x.Id == request.Id);
            if (donor == null) return operation.Failure("خیر یافت نشد");

            var mappedData = _mapper.Map<DonorSingleDTO>(donor);
            return operation.Succedded(mappedData);
        }
    }
}
