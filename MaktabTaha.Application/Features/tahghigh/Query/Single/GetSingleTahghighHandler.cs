using AutoMapper;
using MaktabTaha.Application.DTO_s.tahghigh.Single;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.tahghigh.Query.Single
{
    public class GetSingleTahghighHandler : IRequestHandler<GetSingleTahghighCommand, OperationResult<TahghighSingleDTO>>
    {
        private readonly ITahghighRepository _repository;
        private readonly IMapper _mapper;

        public GetSingleTahghighHandler(ITahghighRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<TahghighSingleDTO>> Handle(GetSingleTahghighCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<TahghighSingleDTO>();

            try {
                var tahghigh = await _repository.GetTahghighSingle(request.Id);
                if (tahghigh == null) return operation.Failure("تحقیق یافت نشد");

                return operation.Succedded(tahghigh);
            }
            catch (Exception ex)
            {
                return operation.Failure(ex.Message);
            }
        }
    }
}
