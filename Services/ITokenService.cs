using WebTest.Models;

namespace WebTest.Services
{
    public interface ITokenService
    {
        string GetToken(User user);
    }
}
