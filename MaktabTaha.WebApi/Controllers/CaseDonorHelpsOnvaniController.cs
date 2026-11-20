using MaktabTaha.Application.Features.caseDonorHelps.Command.Create;
using MaktabTaha.Application.Features.caseDonorHelps.Command.Update;
using MaktabTaha.Application.Features.caseDonorHelps.Query.List;
using MaktabTaha.Application.Features.caseDonorHelpsOnvani.Command.Create;
using MaktabTaha.Application.Features.caseDonorHelpsOnvani.Command.Update;
using MaktabTaha.Application.Features.caseDonorHelpsOnvani.Query.List;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaktabTaha.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseDonorHelpsOnvaniController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCaseDonorHelpsOnvani(CreateCaseDonorHelpsOnvaniCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCaseDonorHelpsOnvani(int id, UpdateCaseDonorHelpsOnvaniCommand command)
        {
            if (id != command.Id) return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{OnvaniId}")]
        public async Task<IActionResult> GetCaseDonorHelpsOnvaniList(int OnvaniId)
        {
            return Ok(await Mediator.Send(new GetCaseDonorHelpsOnvaniListCommand { OnvaniId = OnvaniId }));
        }
    }
}
