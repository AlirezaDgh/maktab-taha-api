using MaktabTaha.Application.DTO_s.tahghigh.Single;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.tahghigh.Query.Single
{
    public class GetSingleTahghighCommand : IRequest<OperationResult<TahghighSingleDTO>>
    {
        public int Id { get; set; }
    }
}
