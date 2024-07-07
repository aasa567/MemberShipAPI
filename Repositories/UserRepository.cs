using WebTest.Models;

namespace WebTest.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public User GetUser(string username, string password)
        {
            return _users.SingleOrDefault(x => x.UserName == username && x.Password == password);
        }

        public User GetUserById(int id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var existingUser = GetUserById(user.Id);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.Role = user.Role;
            }
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}
