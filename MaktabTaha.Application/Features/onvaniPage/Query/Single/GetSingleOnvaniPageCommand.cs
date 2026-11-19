using MaktabTaha.Application.DTO_s.onvaniPage.Single;
using MaktabTaha.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.onvaniPage.Query.Single
{
    public class GetSingleOnvaniPageCommand : IRequest<OperationResult<SingleOnvaniPageDTO>>
    {
        // نمایش جزئیات
        public int Id { get; set; }
    }
}
