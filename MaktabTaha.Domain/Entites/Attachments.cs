using MaktabTaha.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites
{
    public class Attachments : BaseEntity<int>
    {
        public string AttachmentType { get; set; }
        public byte[] Attach  { get; set; }
        public int? PersonId { get; set; }
        public Person? Person { get; set; }
        public int? CaseId { get; set; }
        public Case? Case { get; set; }
        public int? MoshaverehId { get; set; }
        public Moshavereh? Moshavereh { get; set; }
        public int? TahghighId { get; set; }
        public Tahghigh? Tahghigh { get; set; }
        public int? DonorId { get; set; }
        public Donor? Donor { get; set; }
    }
}
