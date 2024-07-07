using WebTest.Models;

namespace WebTest.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
