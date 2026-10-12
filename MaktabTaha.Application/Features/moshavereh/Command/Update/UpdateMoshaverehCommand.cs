using MaktabTaha.Application.DTO_s.Moshavereh.Update;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.moshavereh.Command.Update
{
    public class UpdateMoshaverehCommand : IRequest<OperationResult<UpdateMoshaverehDTO>>
    {
        public string CaseNumber { get; set; }
        public string ClientRequestDescription { get; set; }
        public string MoshaverCode { get; set; }
        public string MoshaverIdea { get; set; }
        public string MoshaverExplaination { get; set; }
        
    }
}
