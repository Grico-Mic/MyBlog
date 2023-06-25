using Microsoft.AspNetCore.Http;
using MyBlog.Servises.DtoModels;

namespace MyBlog.Servises.Interfaces
{
    public interface IAuthService
    {
        StatusModel SignIn(string username, string password, HttpContext httpContext);
       
    }
}
