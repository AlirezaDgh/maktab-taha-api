using AutoMapper;
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

namespace MaktabTaha.Application.Features.onvaniPage.Command.ManagerAccept
{
    public class OnvaniPageManagerAcceptHandler : IRequestHandler<OnvaniPageManagerAcceptCommand, OperationResult<OnvaniPage>>
    {
        private readonly IOnvaniPageRepository _repository;
        private readonly IMapper _mapper;

        public OnvaniPageManagerAcceptHandler(IOnvaniPageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<OnvaniPage>> Handle(OnvaniPageManagerAcceptCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<OnvaniPage>();
            var onvaniPage = await _repository.FirstOrDefaultWithTrack(x => x.Id == request.Id);
            if (onvaniPage == null) return operation.Failure("برگه عنوانی یافت نشد");

            if (onvaniPage.ManagerTasvibStatusId == 2) return operation.Failure("برگه عنوانی توسط مدیر تایید شده است");

            _mapper.Map(request, onvaniPage);
            await _repository.SaveChanges();
            return operation.Succedded(onvaniPage);
        }
    }
}
