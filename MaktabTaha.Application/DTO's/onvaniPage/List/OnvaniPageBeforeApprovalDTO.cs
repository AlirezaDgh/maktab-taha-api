using MaktabTaha.Domain.Entites;
using MaktabTaha.Domain.Entites.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.onvaniPage.List
{
    public class OnvaniPageBeforeApprovalDTO
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string CaseNumber { get; set; }
        public int RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
        public int MoshaverId { get; set; }
        public string MoshaverName { get; set; }
    }
}
