using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public class UserService
    {
        private readonly List<User> users = new();

        public List<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public void Add(User user)
        {
            users.Add(user);
        }

        public void Update(int id, User updatedUser)
        {
            var user = GetById(id);

            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;
                user.Age = updatedUser.Age;
            }
        }

        public void Delete(int id)
        {
            var user = GetById(id);

            if (user != null)
            {
                users.Remove(user);
            }
        }
    }
}
