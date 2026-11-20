using AutoMapper.Internal.Mappers;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.caseDonorHelps.Command.CreateForOnvaniPage
{
    public class CreateCaseDonorHelpsForOnvaniPageCommand : IRequest<OperationResult<CaseDonorHelps>>
    {
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
