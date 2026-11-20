using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDonorHelpsOnvani.Command.Create
{
    public class CreateCaseDonorHelpsOnvaniCommand : IRequest<OperationResult<CaseDonorHelpsOnvani>>
    {
        // کمک های خیرین به عنوانی در مرحله تصویب عنوانی
        public int OnvaniPageId { get; set; }

        public string CaseNumber { get; set; }

        public int RequestTypeId { get; set; }

        //مبلغ
        public decimal MoneyAmount { get; set; }

        public int DonorId { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
