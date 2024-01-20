using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Zaliczenie.Data.Entities;

namespace Zaliczenie.Utils;

public class UserService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly UserManager<User> _userManager;

    
    
    public UserService(AuthenticationStateProvider authenticationStateProvider, UserManager<User> userManager)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _userManager = userManager;
    }
    public async Task<User?> GetCurrentUser()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        if (authState?.User?.Identity?.IsAuthenticated != true) return null;

        return await _userManager.GetUserAsync(authState.User);
    }
    public async Task<List<string>> GetCurrentUserRoles()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        if (authState?.User?.Identity?.IsAuthenticated != true) return new List<string>();

        return authState.User.FindAll(claim => claim.Type == System.Security.Claims.ClaimTypes.Role)
            .Select(claim => claim.Value).ToList();
    }

    public async Task<bool> DoesUserHaveRole(string role)
    {
        var roles = await GetCurrentUserRoles();
        return roles.Contains(role);
    }

    public async Task<int?> GetCurrentUserCompany()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        if (authState?.User?.Identity?.IsAuthenticated != true) return null;

        var user = await _userManager.GetUserAsync(authState.User);

        return user!.CompanyId;
    }
}