using AutoMapper;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MaktabTaha.Domain.Entites.BaseEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Command.Create
{
    public class CreateOnvaniPageHandler : IRequestHandler<CreateOnvaniPageCommand, OperationResult<OnvaniPage>>
    {
        private readonly IOnvaniPageRepository _onvaniRepository;
        private readonly ICaseRepository _caseRepository;
        private readonly IMapper _mapper;

        public CreateOnvaniPageHandler(IOnvaniPageRepository onvaniRepository, ICaseRepository caseRepository, IMapper mapper)
        {
            _onvaniRepository = onvaniRepository;
            _caseRepository = caseRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<OnvaniPage>> Handle(CreateOnvaniPageCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<OnvaniPage>();
            var caseBnf = await _caseRepository.FirstOrDefault(x => x.CaseNumber == request.CaseNumber);

            //if (caseBnf.ActiveStatus != CaseActiveStatus.Active) return operation.Failure("پرونده فعال نمیباشد");
            if ((int)caseBnf.ActiveStatus != 1) return operation.Failure("پرونده فعال نمیباشد");

            if (request.ManagerTasvibStatusId != 2) return operation.Failure("مدیرعامل تایید نکرده است");

            var mappedData = _mapper.Map<OnvaniPage>(request);
            await _onvaniRepository.Create(mappedData);
            return operation.Succedded(mappedData);
        }
    }
}
