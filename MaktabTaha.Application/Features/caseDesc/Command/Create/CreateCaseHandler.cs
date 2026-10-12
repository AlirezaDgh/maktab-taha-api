using AutoMapper;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;

namespace MaktabTaha.Application.Features.caseDesc.Command.Create
{
    public class CreateCaseHandler : IRequestHandler<CreateCaseCommand, OperationResult<Case>>
    {
        private readonly ICaseRepository _repository;
        private readonly IMapper _mapper;

        public CreateCaseHandler(ICaseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<Case>> Handle(CreateCaseCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<Case>();

            var mappedData = _mapper.Map<Case>(request);
            await _repository.Create(mappedData);

            return operation.Succedded(mappedData);
        }
    }
}
