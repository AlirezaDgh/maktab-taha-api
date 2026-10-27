using MaktabTaha.Application.DTO_s.attachment.Single;
using MaktabTaha.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.DTO_s.Moshavereh.Single
{
    public class MoshaverehSingleDTO
    {
        public int Id { get; set; }
        public DateTime MoshaverehDate { get; set; }
        public string CaseNumber { get; set; }
        public string ClientRequestDescription { get; set; }
        public int MoshaverId { get; set; }
        public string MoshaverIdea { get; set; }
        public string MoshaverExplaination { get; set; }
        public List<AttachmentSingleDTO> Attachments { get; set; } = new List<AttachmentSingleDTO>();
    }
}
