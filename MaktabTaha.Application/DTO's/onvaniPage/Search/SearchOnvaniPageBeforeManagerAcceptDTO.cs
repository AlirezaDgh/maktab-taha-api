using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.onvaniPage.Search
{
    public class SearchOnvaniPageBeforeManagerAcceptDTO
    {
        public int? Id { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? CaseNumber { get; set; }
    }
}
