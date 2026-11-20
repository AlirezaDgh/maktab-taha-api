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

namespace MaktabTaha.Application.Features.caseDonorHelpsOnvani.Command.Update
{
    public class UpdateCaseDonorHelpsOnvaniHandler : IRequestHandler<UpdateCaseDonorHelpsOnvaniCommand, OperationResult<CaseDonorHelpsOnvani>>
    {
        private readonly ICaseDonorHelpsOnvaniRepository _repository;
        private readonly IMapper _mapper;
        private readonly IOnvaniPageRepository _onvaniPageRepository;

        public UpdateCaseDonorHelpsOnvaniHandler(ICaseDonorHelpsOnvaniRepository repository, IMapper mapper, IOnvaniPageRepository onvaniPageRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _onvaniPageRepository = onvaniPageRepository;
        }

        public async Task<OperationResult<CaseDonorHelpsOnvani>> Handle(UpdateCaseDonorHelpsOnvaniCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<CaseDonorHelpsOnvani>();
            var caseDonorHelpsOnvani = await _repository.FirstOrDefault(x => x.Id == request.Id);
            if (caseDonorHelpsOnvani == null) return operation.Failure("کمک خیرین به عنوانی یافت نشد");

            var onvaniPage = await _onvaniPageRepository.FirstOrDefault(x => x.CaseNumber == request.CaseNumber);
            if (onvaniPage == null) return operation.Failure("برگه عنوانی مربوطه یافت نشد");
            if (onvaniPage.ManagerTasvibStatusId == 2) return operation.Failure("کمک های عنوانی توسط مدیر تایید شده است و قابل ویرایش نمیباشد");

            _mapper.Map(request, caseDonorHelpsOnvani);
            await _repository.Update(caseDonorHelpsOnvani);
            return operation.Succedded(caseDonorHelpsOnvani);
        }
    }
}
