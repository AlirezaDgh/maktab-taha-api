using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.attachment.Command.Update
{
    public class UpdateAttachmentCommand : IRequest<OperationResult<Attachments>>
    {
        public int Id { get; set; }
        public string? AttachmentName { get; set; }
        public IFormFile? Attach { get; set; }
        public int? PersonId { get; set; }
        public int CaseId { get; set; }
        public int MoshaverehId { get; set; }
    }
}
