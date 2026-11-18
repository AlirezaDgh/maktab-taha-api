using MaktabTaha.Application.Features.caseDonorHelps.Command.Create;
using MaktabTaha.Application.Features.caseDonorHelps.Command.Update;
using MaktabTaha.Application.Features.caseDonorHelps.Query.List;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MaktabTaha.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseDonorHelpsController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCaseDonorHelps(CreateCaseDonorHelpsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCaseDonorHelps(int id, UpdateCaseDonorHelpsCommand command)
        {
            if (id != command.Id) return BadRequest();
                
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{caseNumber}")]
        public async Task<IActionResult> GetCaseDonorHelpsList(string caseNumber)
        {
            return Ok(await Mediator.Send(new GetCaseDonorHelpsListCommand { caseNumber = caseNumber }));
        }
    }
}
