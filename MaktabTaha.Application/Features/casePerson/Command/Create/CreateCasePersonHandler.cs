using AutoMapper;
using MaktabTaha.Application.Features.casePerson.Command.Create;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.casePerson.Command.Create
{
    public class CreateCasePersonHandler : IRequestHandler<CreateCasePersonCommand, OperationResult<CasePerson>>
    {
        private readonly ICasePersonRepository _repository;
        private readonly IMapper _mapper;

        public CreateCasePersonHandler(ICasePersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<CasePerson>> Handle(CreateCasePersonCommand CasePerson, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<CasePerson>();

            var person = await _repository.Exists(x => x.PersonId == CasePerson.PersonId);
            
            
            if (person) return operation.Failure("این فرد در پرونده دیگری وجود دارد");


            var mappedData = _mapper.Map<CasePerson>(CasePerson);
            await _repository.Create(mappedData);
            return operation.Succedded(mappedData);
        }
    }
}
