using MaktabTaha.Application.DTO_s.casePerson.Create;
using MaktabTaha.Application.Helpers;
using MaktabTaha.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Application.Features.casePerson.Command.Create
{
    public class CreateCasePersonCommand : IRequest<OperationResult<List<CasePerson>>>
    {
        public int CaseId { get; set; }

        public List<CreateCasePersonDTO> PersonsInCase { get; set; } = new List<CreateCasePersonDTO>();


    }
}
