using MyBlog.Models;

namespace MyBlog.Servises.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
    }
}
