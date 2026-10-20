using AutoMapper;
using MaktabTaha.Application.Features.casePerson.Command.Create;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.casePerson.Command.Create
{
    public class CreateCasePersonHandler : IRequestHandler<CreateCasePersonCommand, OperationResult<List<CasePerson>>>
    {
        private readonly ICasePersonRepository _repository;
        private readonly ICaseRepository _caseRepository;
        private readonly IMapper _mapper;

        public CreateCasePersonHandler(ICasePersonRepository repository, IMapper mapper, ICaseRepository caseRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _caseRepository = caseRepository;
        }

        public async Task<OperationResult<List<CasePerson>>> Handle(CreateCasePersonCommand request, CancellationToken cancellationToken)
        {

            var operation = new OperationResult<List<CasePerson>>();

            var caseDesc = await _caseRepository.Exists(x => x.Id == request.CaseId);

            if (!caseDesc)
            {
                return operation.Failure("پرونده وجود ندارد");
            }

            if (request.PersonsInCase == null)
            {
                return operation.Failure("لیست اشخاص خالی است");
            }

            var result = new List<CasePerson>();

            foreach(var item in request.PersonsInCase)
            {
                var exists = await _repository.Exists(x => x.CaseId == request.CaseId 
                                                    && x.PersonId == item.PersonId);

                if (exists)
                {
                    return operation.Failure("این شخص در این پرونده موجود است");
                }

                var casePerson = new CasePerson
                {
                    CaseId = request.CaseId,
                    PersonId = item.PersonId,
                    RelationId = item.RelationId,
                    IsDependent = item.IsDependent
                };

                await _repository.Create(casePerson);
                result.Add(casePerson);
            }

            return operation.Succedded(result);
        }
    }
}
