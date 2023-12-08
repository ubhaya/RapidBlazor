using Microsoft.AspNetCore.Mvc;
using RapidBlazor.Old.Application.AccessControl.Commands;
using RapidBlazor.Old.Application.AccessControl.Queries;
using RapidBlazor.Old.WebUI.Shared.AccessControl;
using RapidBlazor.Old.WebUI.Shared.Authorization;

namespace RapidBlazor.Old.WebUI.Server.Controllers.Admin;

[Route("api/Admin/[controller]")]
public class AccessControlController : ApiControllerBase
{
    [HttpGet]
    [Authorize(Permissions.ViewAccessControl)]
    public async Task<ActionResult<AccessControlVm>> GetConfiguration()
    {
        return await Mediator.Send(new GetAccessControlQuery());
    }

    [HttpPut]
    [Authorize(Permissions.ConfigureAccessControl)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateConfiguration(RoleDto updatedRole)
    {
        await Mediator.Send(new UpdateAccessControlCommand(updatedRole.Id, updatedRole.Permissions));

        return NoContent();
    }
}
