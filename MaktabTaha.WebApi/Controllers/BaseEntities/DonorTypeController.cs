using MaktabTaha.Application.Features.baseEntities.donorType.Query.List;
using Microsoft.AspNetCore.Mvc;

namespace MaktabTaha.WebApi.Controllers.BaseEntities;

[ApiController]
[Route("api/[controller]")]
public class DonorTypeController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetDonorTypesList()
    {
        return Ok(await Mediator.Send(new GetDonorTypeListCommand()));
    }
}
