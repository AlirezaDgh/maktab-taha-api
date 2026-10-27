using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.attachment.List
{
    public class AttachmentListDTO
    {
        public int Id { get; set; }
        public string AttachmentType { get; set; }
        public byte[] Attach { get; set; }
        public int? PersonId { get; set; }
        public int? CaseId { get; set; }
        public int? MoshaverehId { get; set; }
        public int? TahghighId { get; set; }
        public int? DonorId { get; set; }
    }
}
