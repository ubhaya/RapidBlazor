using RapidBlazor.Old.Application.Common.Services.Identity;
using RapidBlazor.Old.WebUI.Shared.AccessControl;
using RapidBlazor.Old.WebUI.Shared.Authorization;

namespace RapidBlazor.Old.Application.AccessControl.Queries;

public record GetAccessControlQuery() : IRequest<AccessControlVm>;

public class GetAccessControlQueryHandler : IRequestHandler<GetAccessControlQuery, AccessControlVm>
{
    private readonly IIdentityService _identityService;

    public GetAccessControlQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<AccessControlVm> Handle(GetAccessControlQuery request, CancellationToken cancellationToken)
    {
        var permissions = new List<Permissions>();
        foreach (var permission in PermissionsProvider.GetAll())
        {
            if (permission == Permissions.None) continue;

            permissions.Add(permission);
        }

        var roles = await _identityService.GetRolesAsync(cancellationToken);

        var result = new AccessControlVm(roles, permissions);

        return result;
    }
}
