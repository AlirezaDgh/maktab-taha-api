using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.moshavereh.Command.Create
{
    public class CreateMoshaverehcCommand : IRequest<OperationResult<Moshavereh>>
    {
        public string CaseNumber { get; set; }
        public DateTime MoshaverehDate { get; set; }
        public string ClientRequestDescription { get; set; }
        public int MoshaverId { get; set; }
        public string MoshaverIdea { get; set; }
        public string MoshaverExplaination { get; set; }
    }
}
