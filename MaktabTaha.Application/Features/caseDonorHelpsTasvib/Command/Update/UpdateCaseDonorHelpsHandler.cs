using AutoMapper;
using AutoMapper.Internal.Mappers;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDonorHelps.Command.Update
{
    public class UpdateCaseDonorHelpsHandler : IRequestHandler<UpdateCaseDonorHelpsCommand, OperationResult<CaseDonorHelpsTasvib>>
    {
        private readonly ICaseDonorHelpsTasvibRepository _caseDonorHelpsRepository;
        private readonly IMapper _mapper;
        private readonly ITasvibRepository _tasvibRepository;

        public UpdateCaseDonorHelpsHandler(ICaseDonorHelpsTasvibRepository caseDonorHelpsRepository, IMapper mapper, ITasvibRepository tasvibRepository)
        {
            _caseDonorHelpsRepository = caseDonorHelpsRepository;
            _mapper = mapper;
            _tasvibRepository = tasvibRepository;
        }

        public async Task<OperationResult<CaseDonorHelpsTasvib>> Handle(UpdateCaseDonorHelpsCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<CaseDonorHelpsTasvib>();
            var caseDonorHelps = await _caseDonorHelpsRepository.FirstOrDefault(x => x.Id == request.Id);
            if (caseDonorHelps == null) return operation.Failure("کمک پرونده یافت نشد");

            var tasvib = await _tasvibRepository.FirstOrDefaultWith(request.CaseNumber);
            if (tasvib == null) return operation.Failure("فرم تصویب یافت نشد");

            if (tasvib.Case.CaseStageId != 4) return operation.Failure("پرونده در مرحله تصویب نمی‌باشد");
            if (tasvib.ManagerTasvibStatusId == 2) return operation.Failure("این تصویب مورد تایید مدیر واقع شده است و امکان ویرایش ندارد.");

            _mapper.Map(request, caseDonorHelps);
            await _caseDonorHelpsRepository.Update(caseDonorHelps);
            return operation.Succedded(caseDonorHelps);

        }
    }
}
