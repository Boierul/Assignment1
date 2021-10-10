using Assignment1.Models;

namespace Assignment1.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
        // User Get();
    }
}