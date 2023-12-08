﻿using Microsoft.AspNetCore.Components;
using RapidBlazor.WebUI.Shared.AccessControl;
using RapidBlazor.WebUI.Shared.Authorization;

namespace RapidBlazor.WebUI.Client.Old.Pages.Admin.AccessControl;

public partial class Index
{
    [Inject]
    private IAccessControlClient AccessControlClient { get; set; } = null!;

    private AccessControlVm? Model { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Model = await AccessControlClient.GetConfigurationAsync();
    }

    private async Task Set(RoleDto role, Permissions permission, bool granted)
    {
        role.Set(permission, granted);

        await AccessControlClient.UpdateConfigurationAsync(role);
    }
}
