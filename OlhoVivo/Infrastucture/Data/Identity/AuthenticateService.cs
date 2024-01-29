using Microsoft.AspNetCore.Identity;
using OlhoVivo.Core.Domain.Account;

namespace OlhoVivo.Infra.Data.Identity;

public class AuthenticateService : IAuthenticate
{
    #region Properties
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    #endregion
    
    #region Constructor
    public AuthenticateService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;        
        _userManager = userManager;
    }
    #endregion

    #region Methods
    public async Task<bool> Authenticate(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
        return result.Succeeded;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<bool> RegisterUser(string email, string password)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = email,
            Email = email,
        };

        var result = await _userManager.CreateAsync(applicationUser, password);

        if (result.Succeeded)
            await _signInManager.SignInAsync(applicationUser, isPersistent: false);
        

        return result.Succeeded;
    }
    #endregion
}
