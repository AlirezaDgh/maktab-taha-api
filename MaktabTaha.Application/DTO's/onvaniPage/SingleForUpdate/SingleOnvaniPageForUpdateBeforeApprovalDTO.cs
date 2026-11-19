using MaktabTaha.Domain.Entites;
using MaktabTaha.Domain.Entites.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.onvaniPage.SingleForUpdate
{
    public class SingleOnvaniPageForUpdateBeforeApprovalDTO
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string CaseNumber { get; set; }
        public int RequestTypeId { get; set; }
        public decimal HelpMoney { get; set; }
        public string CreateDescription { get; set; }
        public string MoshaverIdea { get; set; }
        public int HeadOfWorkingGroupId { get; set; }
        public int MoshaverId { get; set; }
    }
}
