using MaktabTaha.Application.DTO_s.donor.Search;
using MaktabTaha.Application.Features.donor.Command.Create;
using MaktabTaha.Application.Features.donor.Command.Delete;
using MaktabTaha.Application.Features.donor.Command.Update;
using MaktabTaha.Application.Features.donor.Query.List;
using MaktabTaha.Application.Features.donor.Query.Single;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MaktabTaha.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateDonor(CreateDonorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            return Ok(await Mediator.Send(new DeleteDonorCommand { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonor(int id, UpdateDonorCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetDonorList([FromQuery] DonorSearchDTO filters)
        {
            return Ok(await Mediator.Send(new GetDonorListCommand { Filters = filters }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleDonor(int id)
        {
            return Ok(await Mediator.Send(new GetSingleDonorCommand { Id = id }));
        }
    }
}
