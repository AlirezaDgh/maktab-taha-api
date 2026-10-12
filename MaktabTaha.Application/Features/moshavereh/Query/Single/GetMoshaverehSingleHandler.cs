using AutoMapper;
using MaktabTaha.Application.DTO_s.Moshavereh.Single;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.moshavereh.Query.Single
{
    public class GetMoshaverehSingleHandler : IRequestHandler<GetMoshaverehSingleCommand, OperationResult<MoshaverehSingleDTO>>
    {
        private readonly IMoshaverehRepository _repository;
        private readonly IMapper _mapper;

        public GetMoshaverehSingleHandler(IMoshaverehRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<MoshaverehSingleDTO>> Handle(GetMoshaverehSingleCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<MoshaverehSingleDTO>();

            var moshavereh = await _repository.GetWithAttach(request.Id);
            if (moshavereh == null) return operation.Failure("پیش تحقیق یافت نشد");

            var mappedData = _mapper.Map<MoshaverehSingleDTO>(moshavereh);
            return operation.Succedded(mappedData);
        }
    }
}
