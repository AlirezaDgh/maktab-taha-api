using AutoMapper;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.attachment.Command.Create
{
    public class CreateAttachmentHandler : IRequestHandler<CreateAttachmentCommand, OperationResult<Attachments>>
    {
        private readonly IAttachmentRepository _repository;

        public CreateAttachmentHandler(IAttachmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<Attachments>> Handle(CreateAttachmentCommand request, CancellationToken cancellationToken)
        {
            var operation = new OperationResult<Attachments>();

            if (request.Attach == null || request.Attach.Length == 0)
                return operation.Failure("فایل انتخاب نشده است");

            using var memoryStream = new MemoryStream();
            await request.Attach.CopyToAsync(memoryStream, cancellationToken);

            var attachment = new Attachments
            {
                AttachmentType = request.AttachmentType,
                Attach = memoryStream.ToArray(),
                PersonId = request.PersonId,
            };

            await _repository.Create(attachment);
            return operation.Succedded(attachment);
        }
    }
}
