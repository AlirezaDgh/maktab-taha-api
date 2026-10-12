using AutoMapper;
using MaktabTaha.Application.DTO_s.Moshavereh.Update;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.moshavereh.Command.Update
{
    public class UpdateMoshaverehHandler : IRequestHandler<UpdateMoshaverehCommand, OperationResult<UpdateMoshaverehDTO>>
    {
        private readonly IMoshaverehRepository _repository;
        private readonly IMapper _mapper;

        public UpdateMoshaverehHandler(IMoshaverehRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<UpdateMoshaverehDTO>> Handle(UpdateMoshaverehCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<UpdateMoshaverehDTO>();

            var moshavereh = await _repository.FirstOrDefaultWith(request.CaseNumber);

            if (moshavereh == null) return operation.Failure("پیش تحقیق یافت نشد");

            if (moshavereh.Case.CaseStageId != 1) return operation.Failure("پرونده در مرحله مشاوره نمی باشد");


            _mapper.Map(request, moshavereh);
            await _repository.Update(moshavereh);

            var mappedData = _mapper.Map<UpdateMoshaverehDTO>(moshavereh);
            return operation.Succedded(mappedData);
        }
    }
}
