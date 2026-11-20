using AutoMapper;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;

namespace MaktabTaha.Application.Features.caseDonorHelps.Command.Create
{
    // کمک های خیرین به پرونده در مرحله تصویب پرونده

    public class CreateCaseDonorHelpsForTasvibHandler : IRequestHandler<CreateCaseDonorHelpsForTasvibCommand, OperationResult<CaseDonorHelps>>
    {
        private readonly ICaseDonorHelpsRepository _caseDonorHelpsRepository;
        private readonly IMapper _mapper;
        private readonly ITasvibRepository _tasvibRepository;
        public CreateCaseDonorHelpsForTasvibHandler(ICaseDonorHelpsRepository caseDonorHelpsRepository, IMapper mapper, ITasvibRepository tasvibRepository)
        {
            _caseDonorHelpsRepository = caseDonorHelpsRepository;
            _mapper = mapper;
            _tasvibRepository = tasvibRepository;
        }

        public async Task<OperationResult<CaseDonorHelps>> Handle(CreateCaseDonorHelpsForTasvibCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<CaseDonorHelps>();
            var tasvib = await _tasvibRepository.FirstOrDefaultWith(request.CaseNumber);
            if (tasvib == null) return operation.Failure("فرم تصویب یافت نشد");

            if (tasvib.Case.CaseStageId != 4) return operation.Failure("پرونده در مرحله تصویب نمی‌باشد");
            if (tasvib.ManagerTasvibStatusId == 2) return operation.Failure("این تصویب مورد تایید مدیر واقع شده است و امکان ویرایش ندارد.");

            var mappedData = _mapper.Map<CaseDonorHelps>(request);
            await _caseDonorHelpsRepository.Create(mappedData);
            return operation.Succedded(mappedData);
        }
    }
}
