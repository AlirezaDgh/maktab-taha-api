using MaktabTaha.Application.DTO_s.Moshavereh.List;
using MaktabTaha.Application.DTO_s.Moshavereh.Search;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.moshavereh.Query.List
{
    public class GetMoshaverehListCommand : IRequest<OperationResult<List<MoshaverehListDTO>>> 
    {
        public MoshaverehSearchDTO Filters { get; set; }

    }
}
