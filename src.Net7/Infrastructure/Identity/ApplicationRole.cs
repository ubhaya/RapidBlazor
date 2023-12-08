using Microsoft.AspNetCore.Identity;
using RapidBlazor.Old.WebUI.Shared.Authorization;

namespace RapidBlazor.Old.Infrastructure.Identity;

public class ApplicationRole : IdentityRole
{
    public Permissions Permissions { get; set; }
}
