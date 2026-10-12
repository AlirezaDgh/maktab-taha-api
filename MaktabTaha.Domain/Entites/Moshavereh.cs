using MaktabTaha.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites
{
    public class Moshavereh : BaseEntity<int>
    {
        // مشاوره / پیش‌تحقیق
        // شماره پیش تحقیق و تاریخ ایجاد در BaseEntity موجود است
        public string CaseNumber { get; set; }
        public Case Case { get; set; }
        public string ClientRequestDescription { get; set; }
        public string MoshaverCode { get; set; }
        public string MoshaverIdea { get; set; }
        public string MoshaverExplaination { get; set; }
        public List<Attachments> Attachments { get; set; } = new List<Attachments>();
    }
}
