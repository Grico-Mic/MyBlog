using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class UsersRepository
    {
        private MyBlogDbContext _context;

        public UsersRepository(MyBlogDbContext context)
        {
            this._context = context;
        }

        public List<User> GetAll ()
        {
            return _context.Users.ToList();
        }
    }
}
