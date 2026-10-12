using MaktabTaha.Application.DTO_s.Moshavereh.List;
using MaktabTaha.Application.DTO_s.Moshavereh.Search;
using MaktabTaha.Application.Features.moshavereh.Command.Create;
using MaktabTaha.Application.Features.moshavereh.Command.Delete;
using MaktabTaha.Application.Features.moshavereh.Command.Update;
using MaktabTaha.Application.Features.moshavereh.Query.List;
using MaktabTaha.Application.Features.moshavereh.Query.Single;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace MaktabTaha.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoshaverehController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateMoshavereh(CreateMoshaverehcCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoshavereh(int id)
        {
            return Ok(await Mediator.Send(new DeleteMoshaverehCommand { Id = id }));
        }

        [HttpPut("{caseNumber}")]
        public async Task<IActionResult> UpdateMoshavereh(string caseNumber, UpdateMoshaverehCommand command)
        {
            if (caseNumber != command.CaseNumber)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetMoshaverehList([FromQuery]MoshaverehSearchDTO filters)
        {
            return Ok(await Mediator.Send(new GetMoshaverehListCommand { Filters = filters }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleMoshavereh(int id)
        {
            return Ok(await Mediator.Send(new GetMoshaverehSingleCommand { Id = id }));
        }


    }
}
