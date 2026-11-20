using MaktabTaha.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites
{
    // مستمری معیشتی
    public class LivePensions : BaseEntity<int>
    {
        // Id داخل BaseEntity همان شماره معیشتی است

        public DateTime? TasvibDate { get; set; }
        public int? TasvibId { get; set; }
        public Tasvib? Tasvib { get; set; }
        public int? OnvaniPageId { get; set; }
        public CaseDonorHelpsTasvib? OnvaniPage { get; set; }
        public string CaseNumber { get; set; }
        public Case Case { get; set; }
        public decimal MonthlyMoneyAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }


    }
}
