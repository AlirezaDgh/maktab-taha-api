using MaktabTaha.Application.DTO_s.caseDonorHelps.Create;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.tasvib.Command.Create
{
    public class CreateTasvibCommand : IRequest<OperationResult<Tasvib>>
    {
        public DateTime TasvibDate { get; set; } = DateTime.Now;
        public int TahghighId { get; set; }
        public string CaseNumber { get; set; }
        public string ClientRequestDescription { get; set; }
        public int MosavebId { get; set; }

        //وضعیت تصویب
        public int TasvibStatusId { get; set; }
        public string TasvibReason { get; set; }
        public string Description { get; set; }

        //وضعیت تایید مدیر
        public int ManagerTasvibStatusId { get; set; }

        public List<CreateCaseDonorHelpsTasvibDTO> CaseDonorHelps { get; set; } = new List<CreateCaseDonorHelpsTasvibDTO>();
    }
}
