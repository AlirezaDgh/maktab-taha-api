using AutoMapper;
using MaktabTaha.Application.DTO_s.caseDonorHelpsOnvani.List;
using MaktabTaha.Application.DTO_s.tasvib.TasvibDetails;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDonorHelpsOnvani.Query.List
{
    public class GetCaseDonorHelpsOnvaniListHandler : IRequestHandler<GetCaseDonorHelpsOnvaniListCommand, OperationResult<List<CaseDonorHelpsOnvaniListDTO>>>
    {   
        private readonly ICaseDonorHelpsOnvaniRepository _repository;
        private readonly IMapper _mapper;

        public GetCaseDonorHelpsOnvaniListHandler(ICaseDonorHelpsOnvaniRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<CaseDonorHelpsOnvaniListDTO>>> Handle(GetCaseDonorHelpsOnvaniListCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<List<CaseDonorHelpsOnvaniListDTO>>();

            var caseDonorHelpsOnvani = await _repository.GetAllCaseHelpsOnvani(request.OnvaniId);

            var mappedData = _mapper.Map<List<CaseDonorHelpsOnvaniListDTO>>(caseDonorHelpsOnvani);

            return operation.Succedded(mappedData);
        }
    }
}
