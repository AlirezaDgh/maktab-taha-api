using MaktabTaha.Application.Features.baseEntities.charityReferralSource.Query.List;
using Microsoft.AspNetCore.Mvc;

namespace MaktabTaha.WebApi.Controllers.BaseEntities;

[ApiController]
[Route("api/[controller]")]
public class CharityReferralSourceController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetCharityReferralSourcesList()
    {
        return Ok(await Mediator.Send(new GetCharityReferralSourceListCommand()));
    }
}
