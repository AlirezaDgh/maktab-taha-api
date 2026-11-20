using MaktabTaha.Domain.Common;
using MaktabTaha.Domain.Entites.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites
{
    public class Tasvib : BaseEntity<int>
    {
        // شماره تصویب همان Id داخل BaseEntity است

        public DateTime TasvibDate { get; set; }
        public int TahghighId { get; set; }
        public Tahghigh Tahghigh { get; set; }
        public string CaseNumber { get; set; }
        [JsonIgnore]
        public Case Case { get; set; }
        public string ClientRequestDescription { get; set; }
        public int MosavebId { get; set; }
        public Donor Mosaveb { get; set; }

        //وضعیت تصویب
        public int TasvibStatusId { get; set; }
        public TasvibStatus TasvibStatus { get; set; }
        public string TasvibReason { get; set; }
        public string Description { get; set; }

        //وضعیت تایید مدیر
        public int ManagerTasvibStatusId { get; set; }
        public ManagerTasvibStatus ManagerTasvibStatus { get; set; }
        [JsonIgnore]
        public List<CaseDonorHelpsTasvib> CaseDonorHelpsTasvib { get; set; } = new List<CaseDonorHelpsTasvib>();
    }

    
}
