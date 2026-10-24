using MaktabTaha.Application.DTO_s.caseDesc.Search;
using MaktabTaha.Application.Features.caseDesc.Command.Create;
using MaktabTaha.Application.Features.caseDesc.Command.Delete;
using MaktabTaha.Application.Features.caseDesc.Command.Update;
using MaktabTaha.Application.Features.caseDesc.Query.List;
using MaktabTaha.Application.Features.caseDesc.Query.Single;
using MaktabTaha.Application.Features.caseDesc.Query.SingleCaseMoshavereh;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaktabTaha.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCase(CreateCaseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{CaseNumber}")]
        public async Task<IActionResult> DeleteCase(string CaseNumber)
        {
            return Ok(await Mediator.Send(new DeleteCaseCommand { CaseNumber = CaseNumber }));
        }

        [HttpPut("{CaseNumber}")]
        public async Task<IActionResult> UpdateCase(string CaseNumber, UpdateCaseCommand command)
        {
            if (CaseNumber != command.CaseNumber)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetCaseList([FromQuery] SearchCaseDTO filters)
        {
            return Ok(await Mediator.Send(new GetCaseListCommand { Filters = filters }));
        }

        [HttpGet("{CaseNumber}")]
        public async Task<IActionResult> GetCaseMoshaverehSingle(string CaseNumber)
        {
            return Ok(await Mediator.Send(new GetSingleCaseMoshaverehCommand { CaseNumber = CaseNumber }));
        }

        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetSingleCase(int id)
        {
            return Ok(await Mediator.Send(new GetSingleCaseCommand { Id = id }));
        }
    }
}
