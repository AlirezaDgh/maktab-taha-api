using MaktabTaha.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.tahghigh.List
{
    public class TahghighListDTO
    {
        //شماره تحقیق
        public int Id { get; set; }
        public string CaseNumber { get; set; }
        public string? SupervisorFirstName { get; set; }
        public string? SupervisorLastName { get; set; }
        public DateTime TahghighDate { get; set; }
    }
}
