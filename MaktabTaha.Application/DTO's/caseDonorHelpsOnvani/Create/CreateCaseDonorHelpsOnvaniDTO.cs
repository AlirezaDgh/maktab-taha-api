using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.caseDonorHelpsOnvani.Create
{
    public class CreateCaseDonorHelpsOnvaniDTO
    {
        public string CaseNumber { get; set; }

        public int RequestTypeId { get; set; }

        //مبلغ
        public decimal MoneyAmount { get; set; }

        public int DonorId { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
