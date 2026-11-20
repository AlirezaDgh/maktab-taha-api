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
    public class CaseDonorHelpsTasvibController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCaseDonorHelpsTasvib(CreateCaseDonorHelpsForTasvibCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCaseDonorHelpsTasvib(int id, UpdateCaseDonorHelpsCommand command)
        {
            if (id != command.Id) return BadRequest();
                
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{caseNumber}")]
        public async Task<IActionResult> GetCaseDonorHelpsTasvibList(string caseNumber)
        {
            return Ok(await Mediator.Send(new GetCaseDonorHelpsTasvibListCommand { caseNumber = caseNumber }));
        }
    }
}
