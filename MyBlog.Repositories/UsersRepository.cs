using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System.Linq;

namespace MyBlog.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private MyBlogDbContext _context;

        public UsersRepository(MyBlogDbContext context)
        {
           _context = context;
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public User GetByUsername (string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
