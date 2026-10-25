using MaktabTaha.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites
{
    public class Moshavereh : BaseEntity<int>
    {
        // مشاوره / پیش‌تحقیق
        // شماره پیش تحقیق در BaseEntity موجود است

        public DateTime MoshaverehDate { get; set; } = DateTime.Now;
        public string CaseNumber { get; set; }

        [JsonIgnore]
        public Case Case { get; set; }
        public string ClientRequestDescription { get; set; }
        public string MoshaverCode { get; set; }
        public string MoshaverIdea { get; set; }
        public string MoshaverExplaination { get; set; }
        public List<Attachments> Attachments { get; set; } = new List<Attachments>();
    }
}
