using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MaktabTaha.Domain.Entites.BaseEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Command.UpdateBeforeManagerAccept
{
    public class UpdateBeforeManagerAcceptCommand : IRequest<OperationResult<OnvaniPage>>
    {
        public int Id { get; set; }
        public int TasvibStatusId { get; set; }
        public string TasvibReason { get; set; }
        public string ApproveDescription { get; set; }
        public int ManagerTasvibStatusId { get; set; }
    }
}
