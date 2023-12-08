using RapidBlazor.Old.Application.Common.Services.Identity;
using RapidBlazor.Old.WebUI.Shared.AccessControl;

namespace RapidBlazor.Old.Application.Roles.Queries;

public record GetRolesQuery : IRequest<RolesVm>;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, RolesVm>
{
    private readonly IIdentityService _identityService;

    public GetRolesQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<RolesVm> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return new RolesVm
        {
            Roles = await _identityService.GetRolesAsync(cancellationToken)
        };
    }
}
