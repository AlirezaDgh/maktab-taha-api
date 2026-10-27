using MaktabTaha.Application.DTO_s.Moshavereh.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.Moshavereh.Search
{
    public class MoshaverehSearchDTO
    {
        public string? CaseNumber { get; set; }
        public string? SupervisorFirstName { get; set; }
        public string? SupervisorLastName { get; set; }
        public int? MoshaverId { get; set; }

        
    }
}
