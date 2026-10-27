using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.tahghigh.Command.Create
{
    public class CreateTahghighCommand : IRequest<OperationResult<Tahghigh>>
    {
        // تاریخ تحقیق
        public DateTime TahghighDate { get; set; } = DateTime.Now;

        // شماره پیش تحقیق
        public int MoshaverehId { get; set; }

        public string ClientDescription { get; set; }

        public int FirstMohagheghId { get; set; }
        public int SecondMohagheghId { get; set; }
        public MohagheghIdea MohagheghIdea { get; set; }
        public string MohagheghDescription { get; set; }
    }
}
