using MaktabTaha.Application.DTO_s.onvaniPage.List;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Query.MainList
{
    // فرم نمایش برگه های عنوانی
    public class GetOnvaniPageMainListCommand : IRequest<OperationResult<OnvaniPageMainListDTO>>
    {
        public string CaseNumber { get; set; }
    }
}
