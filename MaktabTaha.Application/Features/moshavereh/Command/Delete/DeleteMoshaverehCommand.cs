using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.moshavereh.Command.Delete
{
    public class DeleteMoshaverehCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
