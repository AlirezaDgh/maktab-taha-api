using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;

namespace MaktabTaha.Application.Features.caseDonorHelps.Command.Create
{
    public class CreateCaseDonorHelpsForTasvibCommand : IRequest<OperationResult<CaseDonorHelpsTasvib>>
    {
        // کمک های خیرین به پرونده در مرحله تصویب پرونده
        public int TasvibId { get; set; }

        public string CaseNumber { get; set; }

        public int RequestTypeId { get; set; }

        //مبلغ
        public decimal MoneyAmount { get; set; }

        public int DonorId { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
