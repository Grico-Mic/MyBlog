using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Servises.Interfaces;

namespace MyBlog.Servises
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public User GetDetails(string userId)
        {
            return _usersRepository.GetById(int.Parse(userId));
        }
    }
}
