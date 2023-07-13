using MyBlog.Models;
using MyBlog.ViewModels;

namespace MyBlog.Mappings
{
    public static class ViewModelExtensions
    {
        public static Blog ToModel(this BlogCreateModel blog)
        {
            return new Blog()
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                DateCreated = blog.DateCreated
            };
        }
        public static Blog ToModel(this BlogUpdateModel blog)
        {
            return new Blog()
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                DateCreated = blog.DateCreated,
                DateUpdated = blog.DateUpdated
            };

        }
        public static User ToSignUpModel(this AuthSignUpModel authSignUp)
        {
            return new User()
            {
                Username = authSignUp.Username,
                Password = authSignUp.Password,
                Address = authSignUp.Address,
                Email = authSignUp.Email
            };
        }

        public static User ToUpdateModel(this UsersUpdateModel  usersUpdateModel)
        {
            return new User()
            {
                Username = usersUpdateModel.Username,
                Address = usersUpdateModel.Address,
                Email = usersUpdateModel.Email,
                DateUpdated = System.DateTime.Now
            };
        }
    }
}
