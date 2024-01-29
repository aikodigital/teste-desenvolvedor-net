using Microsoft.AspNetCore.Mvc;
using OlhoVivo.Core.Domain.Account;
using WebUI.ViewModel;

namespace WebUI;

public class AccountController : Controller
{
    #region Properties
    private IAuthenticate _authentication;
    #endregion

    #region Constructor
    public AccountController(IAuthenticate authentication)
    {
        _authentication = authentication;
    }
    #endregion

    #region Actions

    #region Login
    [HttpGet]
    public IActionResult Login(string returUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returUrl
        });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await _authentication.Authenticate(model.Email, model.Password);

        if(result)
        {
            if(string.IsNullOrWhiteSpace(model.ReturnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(model.ReturnUrl);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Tentativa de login inválida. (a senha deve ser longa)");
            return View(model);
        }
    }
    #endregion

    #region RegisterUser
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var result = await _authentication.RegisterUser(model.Email, model.Password);

        if(result)
            return Redirect("/");
        else
        {
            ModelState.AddModelError(string.Empty, "Tentativa de registro inválida. (a senha deve ser longa)");
            return View(model);
        }
    }    
    #endregion

    #region Logout

    public async Task<IActionResult> Logout()
    {
        await _authentication.Logout();
        return Redirect("/Account/Login");
    }   
    #endregion

    #endregion
}
