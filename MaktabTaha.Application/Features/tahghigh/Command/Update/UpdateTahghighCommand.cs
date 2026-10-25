using MaktabTaha.Application.DTO_s.tahghigh.Update;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.tahghigh.Command.Update
{
    public class UpdateTahghighCommand : IRequest<OperationResult<UpdateTahghighDTO>>
    {
        public string CaseNumber { get; set; }

        // شماره پیش تحقیق
        public int MoshaverehId { get; set; }

        public string ClientDescription { get; set; }
        public string FirstMohagheghCode { get; set; }
        public string SecondMohagheghCode { get; set; }

        public MohagheghIdea MohagheghIdea { get; set; }
        public string MohagheghDescription { get; set; }
    }
}
