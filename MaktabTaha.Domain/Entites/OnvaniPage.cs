using MaktabTaha.Domain.Common;
using MaktabTaha.Domain.Entites.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites
{
    public class OnvaniPage : BaseEntity<int>
    {
        public DateTime RequestDate { get; set; }
        public string CaseNumber { get; set; }
        public Case Case { get; set; }
        public int RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }
        public decimal HelpMoney { get; set; }
        public string CreateDescription { get; set; }
        public string MoshaverIdea { get; set; }
        public int HeadOfWorkingGroupId { get; set; }
        public Donor HeadOfWorkingGroup { get; set; }
        public int MoshaverId { get; set; }
        public Donor Moshaver { get; set; }
        public int? TasvibStatusId { get; set; }
        public TasvibStatus? TasvibStatus { get; set; }
        public string? TasvibReason { get; set; }
        public string? ApproveDescription { get; set; }
        public int? ManagerTasvibStatusId { get; set; }
        public ManagerTasvibStatus? ManagerTasvibStatus { get; set; }

        [JsonIgnore]
        public List<CaseDonorHelpsOnvani> CaseDonorHelpsOnvani { get; set; } = new List<CaseDonorHelpsOnvani>();
    }
}
