using MaktabTaha.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.tahghigh.Single
{
    public class TahghighSingleDTO
    {
        // شماره تحقیق
        public int Id { get; set; }
        // تاریخ تحقیق
        public DateTime TahghighDate { get; set; } = DateTime.Now;

        public string CaseNumber { get; set; }

        public string ClientDescription { get; set; }
        public int FirstMohagheghId { get; set; }
        public string FirstMohagheghName { get; set; }
        public int SecondMohagheghId { get; set; }
        public string SecondMohagheghName { get; set; }

        public MohagheghIdea MohagheghIdea { get; set; }
        public string MohagheghDescription { get; set; }
    }
}
