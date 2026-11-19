using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Command.ManagerAccept
{
    public class OnvaniPageManagerAcceptCommand : IRequest<OperationResult<OnvaniPage>>
    {
        public int Id { get; set; }
        public int ManagerTasvibStatusId { get; set; }
    }
}
