using MaktabTaha.Application.DTO_s.tahghigh.List;
using MaktabTaha.Application.DTO_s.tahghigh.Search;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.tahghigh.Query.List
{
    public class GetTahghighListCommand : IRequest<OperationResult<List<TahghighListDTO>>>
    {
        public SearchTahghighDTO Filters { get; set; }
    }
}
