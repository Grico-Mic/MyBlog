using MyBlog.Models;

namespace MyBlog.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        User GetByUsername(string username);
        User GetById(int userId);
        bool CheckIfExist(string username, string email);
        void Add(User newUser);
        void Update(User updatedUser);
    }
}
