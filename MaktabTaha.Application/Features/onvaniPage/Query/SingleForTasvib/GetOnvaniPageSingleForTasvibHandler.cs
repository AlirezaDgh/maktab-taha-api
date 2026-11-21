using AutoMapper;
using MaktabTaha.Application.DTO_s.onvaniPage.Single;
using MaktabTaha.Application.DTO_s.onvaniPage.SingleForTasvib;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Query.SingleForTasvib
{
    public class GetOnvaniPageSingleForTasvibHandler : IRequestHandler<GetOnvaniPageSingleForTasvibCommand, OperationResult<OnvaniPageSingleForTasvibDTO>>
    {
        private readonly IOnvaniPageRepository _repository;
        private readonly IMapper _mapper;

        public GetOnvaniPageSingleForTasvibHandler(IOnvaniPageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<OnvaniPageSingleForTasvibDTO>> Handle(GetOnvaniPageSingleForTasvibCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<OnvaniPageSingleForTasvibDTO>();
            var onvaniPage = await _repository.FirstOrDefault(x => x.Id == request.Id);
            if (onvaniPage == null) return operation.Failure("برگه عنوانی یافت نشد");

            var mappedData = _mapper.Map<OnvaniPageSingleForTasvibDTO>(onvaniPage);
            return operation.Succedded(mappedData);
        }
    }
}
