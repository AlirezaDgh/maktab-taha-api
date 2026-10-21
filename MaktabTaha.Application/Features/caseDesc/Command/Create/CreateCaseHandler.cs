using AutoMapper;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;

namespace MaktabTaha.Application.Features.caseDesc.Command.Create
{
    public class CreateCaseHandler : IRequestHandler<CreateCaseCommand, OperationResult<Case>>
    {
        private readonly ICaseRepository _caseRepository;
        private readonly ICasePersonRepository _casePersonRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCaseHandler(ICaseRepository repository, IMapper mapper, ICasePersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            _caseRepository = repository;
            _mapper = mapper;
            _casePersonRepository = personRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<Case>> Handle(CreateCaseCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<Case>();

            if (request.PersonsInCase == null || !request.PersonsInCase.Any())
            {
                return operation.Failure("لیست اشخاص خالی است.");
            } 

            var hasDuplicatePerson = request.PersonsInCase
                .GroupBy(x => x.PersonId)
                .Any(group => group.Count() > 1);

            if (hasDuplicatePerson)
            {
                return operation.Failure("یک شخص فقط یکبار میتواند در هر پرونده ثبت شود.");
            }

            var mappedData = _mapper.Map<Case>(request);

            try
            {
                await _unitOfWork.ExecuteInTransactionAsync(
                    async ct =>
                    {
                        await _caseRepository.CreateNoSave(mappedData);

                        await _unitOfWork.SaveChangesAsync(ct);

                        foreach (var item in request.PersonsInCase)
                        {
                            var casePerson = new CasePerson
                            {
                                CaseId = mappedData.Id,
                                PersonId = item.PersonId,
                                RelationId = item.RelationId,
                                IsDependent = item.IsDependent
                            };

                            await _casePersonRepository.CreateNoSave(casePerson);
                        }

                        await _unitOfWork.SaveChangesAsync(ct);
                    }
                    , cancellationToken);

                return operation.Succedded(mappedData);
            }

            catch(OperationCanceledException)
            {
                throw;
            }

            catch(Exception ex)
            {
                return operation.Failure("خطا در ثبت پرونده با افراد مربوط به آن. هیچ یک از عملیات ها ثبت نهایی نشد.");
            }
        }
    }
}
