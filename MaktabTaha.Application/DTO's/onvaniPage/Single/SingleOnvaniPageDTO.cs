using MaktabTaha.Domain.Entites;
using MaktabTaha.Domain.Entites.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.onvaniPage.Single
{
    public class SingleOnvaniPageDTO
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string CaseNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RequestTypeId { get; set; }
        public string ReuqestTypeName { get; set; }
        public decimal HelpMoney { get; set; }
        public string CreateDescription { get; set; }
        public string MoshaverIdea { get; set; }
        public int HeadOfWorkingGroupId { get; set; }
        public string HeadOfWorkingGroupName { get; set; }
        public int MoshaverId { get; set; }
        public string MoshaverName { get; set; }

    }
}
