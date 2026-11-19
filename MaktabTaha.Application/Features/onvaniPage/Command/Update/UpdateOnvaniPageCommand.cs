using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MaktabTaha.Domain.Entites.BaseEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Command.Update
{
    public class UpdateOnvaniPageCommand : IRequest<OperationResult<OnvaniPage>>
    {
        // ویرایش پیش از تصویب
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string CaseNumber { get; set; }
        public int RequestTypeId { get; set; }
        public decimal HelpMoney { get; set; }
        public string CreateDescription { get; set; }
        public string MoshaverIdea { get; set; }
        public int HeadOfWorkingGroupId { get; set; }
        public int MoshaverId { get; set; }
    }
}
