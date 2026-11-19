using AutoMapper;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;

namespace MaktabTaha.Application.Features.onvaniPage.Command.Approve
{
    public class ApproveOnvaniPageHandler : IRequestHandler<ApproveOnvaniPageCommand, OperationResult<OnvaniPage>>
    {
        private readonly IOnvaniPageRepository _onvaniPageRepository;
        private readonly IMapper _mapper;

        public ApproveOnvaniPageHandler(IOnvaniPageRepository onvaniPageRepository, IMapper mapper)
        {
            _onvaniPageRepository = onvaniPageRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<OnvaniPage>> Handle(ApproveOnvaniPageCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<OnvaniPage>();
            var onvaniPage = await _onvaniPageRepository.FirstOrDefault(x => x.Id == request.Id);
            if (onvaniPage == null) return operation.Failure("برگه عنوانی یافت نشد");

            var mappedData = _mapper.Map(request, onvaniPage);
            await _onvaniPageRepository.SaveChanges();

            return operation.Succedded(mappedData);
        }
    }
}
