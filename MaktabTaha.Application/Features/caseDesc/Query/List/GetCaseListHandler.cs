using AutoMapper;
using MaktabTaha.Application.DTO_s.caseDesc.List;
using MaktabTaha.Application.DTO_s.casePerson.List;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using OfficeOpenXml.Export.HtmlExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDesc.Query.List
{
    public class GetCaseListHandler : IRequestHandler<GetCaseListCommand, OperationResult<List<CaseListDTO>>>
    {
        private readonly ICaseRepository _repository;

        public GetCaseListHandler(ICaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<List<CaseListDTO>>> Handle(GetCaseListCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<List<CaseListDTO>>();

            var cases = await _repository.SearchCaseList(request.Filters);
            
            return operation.Succedded(cases);
        }
    }
}
