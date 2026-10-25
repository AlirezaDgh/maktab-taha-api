using MaktabTaha.Application.DTO_s.tahghigh.List;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.tahghigh.Query.List
{
    public class GetTahghighListHandler : IRequestHandler<GetTahghighListCommand, OperationResult<List<TahghighListDTO>>>
    {
        private readonly ITahghighRepository _repository;

        public GetTahghighListHandler(ITahghighRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<List<TahghighListDTO>>> Handle(GetTahghighListCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<List<TahghighListDTO>>();
            var tahghighs = await _repository.GetAllTahghighList(request.Filters);

            return operation.Succedded(tahghighs);
        }
    }
}
