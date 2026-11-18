using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Command.Delete
{
    public class DeleteOnvaniPageCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
