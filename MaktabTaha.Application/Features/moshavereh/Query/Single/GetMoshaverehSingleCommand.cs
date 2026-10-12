using MaktabTaha.Application.DTO_s.Moshavereh.Single;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.moshavereh.Query.Single
{
    public class GetMoshaverehSingleCommand : IRequest<OperationResult<MoshaverehSingleDTO>>
    {
        public int Id { get; set; }
    }
}
