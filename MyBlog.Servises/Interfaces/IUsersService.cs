using MyBlog.Models;
using MyBlog.Servises.DtoModels;
using System.Collections.Generic;

namespace MyBlog.Servises.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
        StatusModel UpdateUser(User user);
        List<User> GetAll();
        StatusModel ToggleAdminRole(int id);
        StatusModel Delete(int id);
    }
}
