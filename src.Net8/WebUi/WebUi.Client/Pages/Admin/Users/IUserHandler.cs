using RapidBlazor.WebUi.Shared.AccessControl;

namespace RapidBlazor.WebUi.Client.Pages.Admin.Users;

public interface IUserHandler
{
    Task<UserDetailsVm> GetUserAsync(string userId);
    Task PutUserAsync(string userId, UserDto user);
}
