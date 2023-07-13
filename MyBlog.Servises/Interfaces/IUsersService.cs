using MyBlog.Models;
using MyBlog.Servises.DtoModels;

namespace MyBlog.Servises.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
        StatusModel UpdateUser(User user);
    }
}
