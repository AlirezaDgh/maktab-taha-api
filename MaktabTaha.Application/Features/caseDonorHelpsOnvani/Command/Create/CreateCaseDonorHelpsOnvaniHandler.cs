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

namespace MaktabTaha.Application.Features.caseDonorHelpsOnvani.Command.Create
{
    public class CreateCaseDonorHelpsOnvaniHandler : IRequestHandler<CreateCaseDonorHelpsOnvaniCommand, OperationResult<CaseDonorHelpsOnvani>>
    {
        private readonly ICaseDonorHelpsOnvaniRepository _repository;
        private readonly IMapper _mapper;
        private readonly IOnvaniPageRepository _onvaniPageRepository;

        public CreateCaseDonorHelpsOnvaniHandler(ICaseDonorHelpsOnvaniRepository repository, IMapper mapper, IOnvaniPageRepository onvaniPageRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _onvaniPageRepository = onvaniPageRepository;
        }

        public async Task<OperationResult<CaseDonorHelpsOnvani>> Handle(CreateCaseDonorHelpsOnvaniCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<CaseDonorHelpsOnvani>();
            var onvaniPage = await _onvaniPageRepository.FirstOrDefault(x => x.CaseNumber == request.CaseNumber);
            if (onvaniPage == null) return operation.Failure("برگه عنوانی مربوطه یافت نشد");
            if (onvaniPage.ManagerTasvibStatusId == 2) return operation.Failure("کمک های عنوانی توسط مدیر تایید شده است و قابل ویرایش نمیباشد");


            var mappedData = _mapper.Map<CaseDonorHelpsOnvani>(request);
            await _repository.Create(mappedData);
            return operation.Succedded(mappedData);
        }
    }
}
