using MaktabTaha.Application.DTO_s.caseDonorHelps.Create;
using MaktabTaha.Application.DTO_s.caseDonorHelpsOnvani.Create;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;

namespace MaktabTaha.Application.Features.onvaniPage.Command.Approve
{
    public class ApproveOnvaniPageCommand : IRequest<OperationResult<OnvaniPage>>
    {
        public int Id { get; set; }
        public int TasvibStatusId { get; set; }
        public string TasvibReason { get; set; }
        public string ApproveDescription { get; set; }
        public int ManagerTasvibStatusId { get; set; }

        public List<CreateCaseDonorHelpsOnvaniDTO> CaseDonorHelpsOnvani { get; set; } = new List<CreateCaseDonorHelpsOnvaniDTO>();

    }
}
