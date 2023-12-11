namespace RapidBlazor.Application.Common.Services.Identity;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);
}
