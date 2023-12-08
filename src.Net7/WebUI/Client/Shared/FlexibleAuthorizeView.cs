using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using RapidBlazor.Old.WebUI.Shared.Authorization;

namespace RapidBlazor.Old.WebUI.Client.Shared;

public class FlexibleAuthorizeView : AuthorizeView
{
    [Parameter]
    [EditorRequired]
#pragma warning disable BL0007
    public Permissions Permissions
#pragma warning restore BL0007
    {
        get => string.IsNullOrEmpty(Policy) ? Permissions.None : PolicyNameHelper.GetPermissionsFrom(Policy);
        set => Policy = PolicyNameHelper.GeneratePolicyNameFor(value);
    }
}
