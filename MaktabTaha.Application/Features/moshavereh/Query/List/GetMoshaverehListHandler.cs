using AutoMapper;
using MaktabTaha.Application.DTO_s.Moshavereh.List;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.moshavereh.Query.List
{
    public class GetMoshaverehListHandler : IRequestHandler<GetMoshaverehListCommand, OperationResult<List<MoshaverehListDTO>>>
    {
        private readonly IMoshaverehRepository _repository;

        public GetMoshaverehListHandler(IMoshaverehRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<List<MoshaverehListDTO>>> Handle(GetMoshaverehListCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<List<MoshaverehListDTO>>();

            var moshaverehs = await _repository.SearchMoshaverehList(request.Filters);

            return operation.Succedded(moshaverehs);
        }
    }
}
