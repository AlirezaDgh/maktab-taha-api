using MaktabTaha.Application.Features.caseDesc.Command.Create;
using MaktabTaha.Application.Features.tahghigh.Command.Create;
using MaktabTaha.Application.Features.tahghigh.Command.Delete;
using MaktabTaha.Application.Features.tahghigh.Command.Update;
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
    }
}
