using MyBlog.Models;
using System.Collections.Generic;

namespace MyBlog.Repositories.Interfaces
{
    public interface IUsersRepository : IBaseRepository<User>
    {
        User GetByUsername(string username);
        bool CheckIfExist(string username, string email);
    }
       
}
