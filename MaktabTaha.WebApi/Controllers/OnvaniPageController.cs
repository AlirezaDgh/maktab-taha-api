using MaktabTaha.Application.DTO_s.onvaniPage.Search;
using MaktabTaha.Application.Features.onvaniPage.Command.Approve;
using MaktabTaha.Application.Features.onvaniPage.Command.Create;
using MaktabTaha.Application.Features.onvaniPage.Command.Delete;
using MaktabTaha.Application.Features.onvaniPage.Command.ManagerAccept;
using MaktabTaha.Application.Features.onvaniPage.Command.Update;
using MaktabTaha.Application.Features.onvaniPage.Command.UpdateBeforeManagerAccept;
using MaktabTaha.Application.Features.onvaniPage.Query.List;
using MaktabTaha.Application.Features.onvaniPage.Query.ListBeforeManagerAccept;
using MaktabTaha.Application.Features.onvaniPage.Query.MainList;
using MaktabTaha.Application.Features.onvaniPage.Query.Single;
using MaktabTaha.Application.Features.onvaniPage.Query.SingleForTasvib;
using MaktabTaha.Application.Features.onvaniPage.Query.SingleForUpdate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MaktabTaha.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnvaniPageController : BaseApiController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateOnvaniPage(CreateOnvaniPageCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Approve")]
        public async Task<IActionResult> ApproveOnvaniPage(ApproveOnvaniPageCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Manager-Accept")]
        public async Task<IActionResult> ManagerAcceptOnvaniPage(OnvaniPageManagerAcceptCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnvaniPage(int id)
        {
            return Ok(await Mediator.Send(new DeleteOnvaniPageCommand { Id = id }));
        }

        [HttpPut("{id}/Before-Approval")]
        public async Task<IActionResult> UpdateOnvaniPageBeforeApproval(int id, UpdateOnvaniPageCommand command)
        {
            // ویرایش پیش از تصویب

            if (command.Id != id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}/Before-Manager-Accept")]
        public async Task<IActionResult> UpdateOnvaniPageBeforeManagerAccept(int id, UpdateBeforeManagerAcceptCommand command)
        {
            if (command.Id != id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{id}/Details")]
        public async Task<IActionResult> GetSingleOnvaniPage(int id)
        {
            // نمایش جزئیات

            return Ok(await Mediator.Send(new GetSingleOnvaniPageCommand { Id = id }));
        }

        [HttpGet("{id}/For-Update")]
        public async Task<IActionResult> GetSingleOnvaniPageForUpdate(int id)
        {
            // جزئیات برای ویرایش

            return Ok(await Mediator.Send(new GetSingleOnvaniPageForUpdateCommand { Id = id }));
        }

        [HttpGet("List-Before-Approval")]
        public async Task<IActionResult> GetOnvaniPageBeforeApprovalList([FromQuery] SearchOnvaniPageBeforeApprovalDTO filters)
        {
            return Ok(await Mediator.Send(new GetOnvaniPageBeforeApprovalListCommand { Filters = filters }));
        }

        [HttpGet("List-Before-Manager-Accept")]
        public async Task<IActionResult> GetOnvaniPageListBeforeManagerAccept([FromQuery] SearchOnvaniPageBeforeManagerAcceptDTO filters)
        {
            return Ok(await Mediator.Send(new GetOnvaniPageListBeforeManagerAcceptCommand { Filters = filters }));
        }


        [HttpGet("{caseNumber}/GetMainList")]
        public async Task<IActionResult> GetOnvaniPageMainList(string caseNumber)
        {
            // قرم نمایش برگه های عنوانی
            
            return Ok(await Mediator.Send(new GetOnvaniPageMainListCommand { CaseNumber = caseNumber }));
        }

        [HttpGet("{id}/Details/For-Tasvib")]
        public async Task<IActionResult> GetSingleOnvaniPageForTasvib(int id)
        {
            // جزئیاتی که در فرم نمایش نوشته شده

            return Ok(await Mediator.Send(new GetOnvaniPageSingleForTasvibCommand { Id = id }));
        }
    }
}
