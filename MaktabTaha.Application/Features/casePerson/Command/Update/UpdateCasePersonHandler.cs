using AutoMapper;
using MaktabTaha.Application.Features.casePerson.Command.Update;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.casePerson.Command.Update
{
    public class UpdateCasePersonHandler : IRequestHandler<UpdateCasePersonCommand, OperationResult<CasePerson>>
    {
        private readonly ICasePersonRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCasePersonHandler(ICasePersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<CasePerson>> Handle(UpdateCasePersonCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<CasePerson>();

            var casePerson = await _repository.FirstOrDefault(x => x.Id == request.Id);
            if (casePerson == null) return operation.Failure("موجود نمیباشد");
            _mapper.Map(request, casePerson);
            await _repository.Update(casePerson);
            return operation.Succedded(casePerson);
        }
    }
}
