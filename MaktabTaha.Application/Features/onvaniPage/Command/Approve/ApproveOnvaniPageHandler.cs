using AutoMapper;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;

namespace MaktabTaha.Application.Features.onvaniPage.Command.Approve
{
    public class ApproveOnvaniPageHandler : IRequestHandler<ApproveOnvaniPageCommand, OperationResult<OnvaniPage>>
    {
        private readonly IOnvaniPageRepository _onvaniPageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICaseDonorHelpsOnvaniRepository _caseDonorHelpsOnvaniRepository;

        public ApproveOnvaniPageHandler(IOnvaniPageRepository onvaniPageRepository, IMapper mapper, IUnitOfWork unitOfWork, ICaseDonorHelpsOnvaniRepository caseDonorHelpsOnvaniRepository)
        {
            _onvaniPageRepository = onvaniPageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _caseDonorHelpsOnvaniRepository = caseDonorHelpsOnvaniRepository;
        }

        public async Task<OperationResult<OnvaniPage>> Handle(ApproveOnvaniPageCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<OnvaniPage>();
            var onvaniPage = await _onvaniPageRepository.FirstOrDefaultWithTrack(x => x.Id == request.Id);
            if (onvaniPage == null) return operation.Failure("برگه عنوانی یافت نشد");

            try
            {
                await _unitOfWork.ExecuteInTransactionAsync(
                    async ct =>
                    {
                        var mappedData = _mapper.Map(request, onvaniPage);
                        await _onvaniPageRepository.SaveChanges();

                        foreach (var item in request.CaseDonorHelpsOnvani)
                        {
                            var caseDonorHelpsOnvani = new CaseDonorHelpsOnvani
                            {
                                OnvaniPageId = mappedData.Id,
                                CaseNumber = item.CaseNumber,
                                RequestTypeId = item.RequestTypeId,
                                MoneyAmount = item.MoneyAmount,
                                DonorId = item.DonorId,
                                FromDate = item.FromDate,
                                ToDate = item.ToDate
                            };

                            await _caseDonorHelpsOnvaniRepository.CreateNoSave(caseDonorHelpsOnvani);
                        }
                        await _unitOfWork.SaveChangesAsync(ct);

                    },
                    cancellationToken);

                return operation.Succedded(onvaniPage);
            }
            catch(OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return operation.Failure("خطا در تصویب برگه عنوانی و کمک های خیرین مربوط به آن عنوانی. هیچ یک از عملیات ها انجام نمیشوند " + ex.Message);

            }
        }
    }
}
