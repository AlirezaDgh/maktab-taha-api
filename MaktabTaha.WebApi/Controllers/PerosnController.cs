using MaktabTaha.Application.DTO_s.person.Search;
using MaktabTaha.Application.Features.person.Command.Create;
using MaktabTaha.Application.Features.person.Command.Delete;
using MaktabTaha.Application.Features.person.Command.Update;
using MaktabTaha.Application.Features.person.Query.List;
using MaktabTaha.Application.Features.person.Query.SearchCasePerson;
using MaktabTaha.Application.Features.person.Query.Single;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace MaktabTaha.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerosnController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreatePerson(CreatePersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            return Ok(await Mediator.Send(new DeletePersonCommand { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, UpdatePersonCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetPerosnList([FromQuery] SearchPersonListDTO filter)
        {
            return Ok(await Mediator.Send(new GetPersonListCommand { Filters = filter }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonSingle(int id)
        {
            return Ok(await Mediator.Send(new GetPersonSingleCommand { Id = id }));
        }

        [HttpGet("/CasePerson")]
        public async Task<IActionResult> GetCasePerson([FromQuery] SearchCasePersonListDTO filter)
        {
            return Ok(await Mediator.Send(new GetCasePersonListCommand { Filters = filter }));
        }
    }
}
