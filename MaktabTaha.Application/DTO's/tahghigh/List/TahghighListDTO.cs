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
        public int Id { get; set; }
        public string TahghighNumber { get; set; }

        // تاریخ تحقیق
        public DateTime TahghighDate { get; set; } = DateTime.Now;

        // شماره پیش تحقیق
        public int MoshaverehId { get; set; }

        public string ClientDescription { get; set; }
        public string FirstMohagheghCode { get; set; }
        public string SecondMohagheghCode { get; set; }

        public MohagheghIdea MohagheghIdea { get; set; }
        public string MohagheghDescription { get; set; }
    }
}
