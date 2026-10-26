using AutoMapper;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;
using OfficeOpenXml.Export.HtmlExport.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.donor.Command.Create
{
    public class CreateDonorHandler : IRequestHandler<CreateDonorCommand, OperationResult<Donor>>
    {
        private readonly IDonorRepository _repository;
        private readonly IMapper _mapper;

        public CreateDonorHandler(IDonorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<Donor>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<Donor>();

            var mappedData = _mapper.Map<Donor>(request);

            await _repository.Create(mappedData);
            return operation.Succedded(mappedData);
        }
    }
}
