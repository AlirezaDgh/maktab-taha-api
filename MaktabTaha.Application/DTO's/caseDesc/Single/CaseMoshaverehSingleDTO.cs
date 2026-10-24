using MaktabTaha.Domain.Entites.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.caseDesc.Single
{
    public class CaseMoshaverehSingleDTO
    {
        public int Id { get; set; }
        public string SupervisorFirstName { get; set; }
        public string SupervisorLastName { get; set; }
        public int HouseHeadStatusId { get; set; }
        public int CaseStageId { get; set; }
    }
}
