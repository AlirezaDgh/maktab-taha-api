using AutoMapper;
using MaktabTaha.Application.DTO_s.tahghigh.Update;
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

namespace MaktabTaha.Application.Features.tahghigh.Command.Update
{
    public class UpdateTahghighHandler : IRequestHandler<UpdateTahghighCommand, OperationResult<UpdateTahghighDTO>>
    {
        private readonly ITahghighRepository _tahghighRepository;
        private readonly ICaseRepository _caseRepository;
        private readonly IMapper _mapper;

        public UpdateTahghighHandler(ITahghighRepository tahghighRepository, ICaseRepository caseRepository, IMapper mapper)
        {
            _tahghighRepository = tahghighRepository;
            _caseRepository = caseRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<UpdateTahghighDTO>> Handle(UpdateTahghighCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<UpdateTahghighDTO>();

            //var caseBnf = await _caseRepository.FirstOrDefault(x => x.CaseNumber == request.CaseNumber);
            //if (caseBnf.CaseStageId != 3) return operation.Failure("پرونده در مرحله تحقیق نمیباشد");

            //var tahghigh = await _tahghighRepository.FirstOrDefaultWithTrack(x => x.Moshavereh.CaseNumber == request.CaseNumber);
            //if (tahghigh == null) return operation.Failure("تحقیق یافت نشد");

            //_mapper.Map(request, tahghigh);
            //tahghigh.UpdatedDate = DateTime.UtcNow;
            //await _tahghighRepository.Update(tahghigh);

            //var mappedData = _mapper.Map<UpdateTahghighDTO>(tahghigh);
            //return operation.Succedded(mappedData);

            var tahghigh = await _tahghighRepository.FirstOrDefaultWith(request.CaseNumber);
            if (tahghigh == null) return operation.Failure("تحقیق یافت نشد");

            if (tahghigh.Moshavereh.Case.CaseStageId != 3) return operation.Failure("پرونده در مرحله تحقیق نمیباشد");

            _mapper.Map(request, tahghigh);
            tahghigh.UpdatedDate = DateTime.UtcNow;
            await _tahghighRepository.Update(tahghigh);

            var mappedData = _mapper.Map<UpdateTahghighDTO>(tahghigh);
            return operation.Succedded(mappedData);

        }
    }
}
