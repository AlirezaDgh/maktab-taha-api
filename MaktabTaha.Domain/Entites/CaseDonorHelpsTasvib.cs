using MaktabTaha.Domain.Common;
using MaktabTaha.Domain.Entites.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites
{
    // کمک های خیرین به پرونده تصویب
    public class CaseDonorHelpsTasvib : BaseEntity<int>
    {
        // Id در BaseEntity موجود است.

        public int TasvibId { get; set; }
        public Tasvib Tasvib { get; set; }

        public string CaseNumber { get; set; }
        public Case Case { get; set; }

        public int RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }

        //مبلغ
        public decimal MoneyAmount { get; set; }

        public int DonorId { get; set; }
        public Donor Donor { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
