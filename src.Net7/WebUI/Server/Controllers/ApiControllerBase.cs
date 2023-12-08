using MediatR;
using Microsoft.AspNetCore.Mvc;
using RapidBlazor.Old.WebUI.Server.Filters;

namespace RapidBlazor.Old.WebUI.Server.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
