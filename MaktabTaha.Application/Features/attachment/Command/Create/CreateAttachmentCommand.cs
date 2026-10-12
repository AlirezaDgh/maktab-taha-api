using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MaktabTaha.Application.Features.attachment.Command.Create
{
    public class CreateAttachmentCommand : IRequest<OperationResult<Attachments>>
    {
        public string AttachmentType { get; set; }
        public IFormFile Attach { get; set; }
        public int? PersonId { get; set; }
        public int CaseId { get; set; }
        public int MoshaverehId { get; set; }
    }
}

