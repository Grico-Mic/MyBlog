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

        public void Add(User newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
        }

        public bool CheckIfExist(string username, string email)
        {
            return _context.Users.Any(x => x.Username == username || x.Email == email);
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public User GetByUsername (string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public void Update(User updatedUser)
        {
             _context.Users.Update(updatedUser);
            _context.SaveChanges();

        }
    }
}
