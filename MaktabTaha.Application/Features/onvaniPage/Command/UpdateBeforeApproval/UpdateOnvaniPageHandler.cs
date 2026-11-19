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

namespace MaktabTaha.Application.Features.onvaniPage.Command.Update
{
    public class UpdateOnvaniPageHandler : IRequestHandler<UpdateOnvaniPageCommand, OperationResult<OnvaniPage>>
    {
        // ویرایش پیش از تصویب

        private readonly IOnvaniPageRepository _repository;
        private readonly IMapper _mapper;

        public UpdateOnvaniPageHandler(IOnvaniPageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<OnvaniPage>> Handle(UpdateOnvaniPageCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<OnvaniPage>();
            var onvaniPage = await _repository.FirstOrDefault(x => x.Id == request.Id);
            if (onvaniPage == null) return operation.Failure("برکه عنوانی یافت نشد");
            if (onvaniPage.TasvibStatusId == 2) return operation.Failure("برگه عنوانی تصویب شده است و قابل ویرایش نمیباشد");

            _mapper.Map(request, onvaniPage);
            await _repository.Update(onvaniPage);
            return operation.Succedded(onvaniPage);
        }
    }
}
