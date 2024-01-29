using Microsoft.AspNetCore.Identity;
using OlhoVivo.Core.Domain.Account;
using OlhoVivo.Infra.Data.Identity;

namespace OlhoVivo.Infra.Data;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    #region Properties
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    #endregion

    #region Constructor
    public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
    #endregion

    #region Methods
    public void SeedUsers()
    {
        #region User
        if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
        {
            var user = new ApplicationUser();
            
            user.UserName = "usuario@localhost";
            user.Email = "usuario@localhost";
            user.NormalizedUserName = "USUARIO@LOCALHOST";
            user.NormalizedEmail = "USUARIO@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            var result = _userManager.CreateAsync(user, "Numsey#2024").Result;

            if (result.Succeeded)
                _userManager.AddToRoleAsync(user, "User").Wait();            
        }
        #endregion

        #region Admin
        if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
        {
            var admin = new ApplicationUser();
            
            admin.UserName = "admin@localhost";
            admin.Email = "admin@localhost";
            admin.NormalizedUserName = "ADMIN@LOCALHOST";
            admin.NormalizedEmail = "ADMIN@LOCALHOST";
            admin.EmailConfirmed = true;
            admin.LockoutEnabled = false;
            admin.SecurityStamp = Guid.NewGuid().ToString();

            var result = _userManager.CreateAsync(admin, "Numsey#2024").Result;

            if (result.Succeeded)
                _userManager.AddToRoleAsync(admin, "Admin").Wait();            
        }
        #endregion
    } 

    public void SeedRoles()
    {
        #region User
        if(!_roleManager.RoleExistsAsync("User").Result)
        {
            var role = new IdentityRole();

            role.Name = "User";
            role.NormalizedName = "USER";

            var result = _roleManager.CreateAsync(role).Result;
        }
        #endregion

        #region Admin
        if(!_roleManager.RoleExistsAsync("Admin").Result)
        {
            var role = new IdentityRole();

            role.Name = "Admin";
            role.NormalizedName = "ADMIN";

            var result = _roleManager.CreateAsync(role).Result;
        }
        #endregion
    }   
    #endregion
    
}
