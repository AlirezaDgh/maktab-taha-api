using AutoMapper;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Command.UpdateBeforeManagerAccept
{
    public class UpdateBeforeManagerAcceptHandler : IRequestHandler<UpdateBeforeManagerAcceptCommand, OperationResult<OnvaniPage>>
    {
        private readonly IOnvaniPageRepository _repository;
        private readonly IMapper _mapper;

        public UpdateBeforeManagerAcceptHandler(IOnvaniPageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<OnvaniPage>> Handle(UpdateBeforeManagerAcceptCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<OnvaniPage>();
            var onvaniPage = await _repository.FirstOrDefault(x => x.Id == request.Id);
            if (onvaniPage == null) return operation.Failure("برکه عنوانی یافت نشد");
            if (onvaniPage.ManagerTasvibStatusId == 2) return operation.Failure("برگه عنوانی توسط مدیر تایید شده است و قابل ویرایش نمیباشد");

            _mapper.Map(request, onvaniPage);
            await _repository.Update(onvaniPage);
            return operation.Succedded(onvaniPage);
        }
    }
}
