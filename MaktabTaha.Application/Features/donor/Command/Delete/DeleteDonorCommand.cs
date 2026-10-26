using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.donor.Command.Delete
{
    public class DeleteDonorCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
