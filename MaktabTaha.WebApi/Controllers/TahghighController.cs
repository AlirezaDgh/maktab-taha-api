using MaktabTaha.Application.DTO_s.tahghigh.Search;
using MaktabTaha.Application.Features.caseDesc.Command.Create;
using MaktabTaha.Application.Features.tahghigh.Command.Create;
using MaktabTaha.Application.Features.tahghigh.Command.Delete;
using MaktabTaha.Application.Features.tahghigh.Command.Update;
using MaktabTaha.Application.Features.tahghigh.Query.List;
using MaktabTaha.Application.Features.tahghigh.Query.Single;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaktabTaha.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TahghighController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateTahghigh(CreateTahghighCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTahghigh(int id)
        {
            return Ok(await Mediator.Send(new DeleteTahghighCommand { Id = id }));
        }

        [HttpPut("caseNumber")]
        public async Task<IActionResult> UpdateTahghigh(string caseNumber, UpdateTahghighCommand command)
        {
            if (caseNumber != command.CaseNumber)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTahghighs([FromQuery] SearchTahghighDTO filters)
        {
            return Ok(await Mediator.Send(new GetTahghighListCommand { Filters = filters }));
        }

        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetSingleTahghigh(int id)
        {
            return Ok(await Mediator.Send(new GetSingleTahghighCommand{ Id = id }));
        }
    }
}
