namespace OlhoVivo.Core.Domain.Account;

public interface IAuthenticate
{
    Task<bool> Authenticate(string email, string password);
    Task<bool> RegisterUser(string email, string password);
    Task Logout();
}
