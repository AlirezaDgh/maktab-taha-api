using AutoMapper;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Application.Interfaces.Repositories.BaseEntities;
using MaktabTaha.Domain.Entites;
using MaktabTaha.Domain.Entites.BaseEntities;
using MediatR;

namespace MaktabTaha.Application.Features.tasvib.Command.Create
{
    public class CreateTasvibHandler : IRequestHandler<CreateTasvibCommand, OperationResult<Tasvib>>
    {
        private readonly ITasvibRepository _tasvibRepository;
        private readonly ICaseRepository _caseRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICaseDonorHelpsTasvibRepository _caseDonorHelpsRepository;

        public CreateTasvibHandler(ITasvibRepository tasvibRepository, ICaseRepository caseRepository, IMapper mapper, IUnitOfWork unitOfWork, ICaseDonorHelpsTasvibRepository caseDonorHelpsRepository)
        {
            _tasvibRepository = tasvibRepository;
            _caseRepository = caseRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _caseDonorHelpsRepository = caseDonorHelpsRepository;
        }

        public async Task<OperationResult<Tasvib>> Handle(CreateTasvibCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<Tasvib>();
            var caseBnf = await _caseRepository.FirstOrDefaultWithTrack(x => x.CaseNumber == request.CaseNumber);
            if (caseBnf == null) return operation.Failure("پرونده‌ای وجود ندارد");

            if (caseBnf.CaseStageId != 3) return operation.Failure("پرونده در مرحله تحقیق نمیباشد");

            var mappedData = _mapper.Map<Tasvib>(request);

            try
            {
                await _unitOfWork.ExecuteInTransactionAsync(
                    async ct =>
                    {
                        await _tasvibRepository.Create(mappedData);

                        foreach (var item in request.CaseDonorHelps)
                        {
                            var caseDonorHelps = new CaseDonorHelpsTasvib
                            {
                                TasvibId = mappedData.Id,
                                CaseNumber = item.CaseNumber,
                                RequestTypeId = item.RequestTypeId,
                                MoneyAmount = item.MoneyAmount,
                                DonorId = item.DonorId,
                                FromDate = item.FromDate,
                                ToDate = item.ToDate
                            };

                            await _caseDonorHelpsRepository.CreateNoSave(caseDonorHelps);
                        }

                        await _unitOfWork.SaveChangesAsync(ct);
                    }
                    , cancellationToken);

                caseBnf.CaseStageId = 4;
                await _caseRepository.Update(caseBnf);
                return operation.Succedded(mappedData);
            }
            catch(OperationCanceledException)
            {
                throw;
            }

            catch (Exception ex)
            {
                return operation.Failure("خطا در ثبت تصویب و کمک های خیرین مربوط به آن پرونده. هیچ یک از عملیات ها انجام نمیشوند " + ex.Message);
            }
        }
    }
}
