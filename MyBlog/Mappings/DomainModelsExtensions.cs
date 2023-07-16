using MyBlog.Models;
using MyBlog.ViewModels;

namespace MyBlog.Mappings
{
    public static class DomainModelsExtensions
    {
        public static BlogOverviewModel ToOverviewModel(this Blog blog)
        {
            return new BlogOverviewModel()
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                DateCreated = blog.DateCreated
            };
        }

        public static BlogManageBlogsModel ToManageBlogsModel(this Blog blog)
        {
            return new BlogManageBlogsModel()
            {
                Id = blog.Id,
                Title = blog.Title
            };
        }

        public static BlogDetailsModel ToDetailsModel(this Blog blog)
        {
            return new BlogDetailsModel()
            {
                Title = blog.Title,
                Description = blog.Description,
                DateCreated = blog.DateCreated
            };
        }

        public static BlogUpdateModel ToUpdateModel(this Blog blog)
        {
            return new BlogUpdateModel()
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                DateCreated = blog.DateCreated,
                DateUpdated = blog.DateUpdated
            };
        }

        public static UsersDetailsModel ToUsersDetailsModel(this User viewModel)
        {
            return new UsersDetailsModel()
            {
               Username = viewModel.Username,
               Email = viewModel.Email,
               Address = viewModel.Address
            };
        }

        public static UsersUpdateModel ToUpdateModel(this User user)
        {
            return new UsersUpdateModel()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Address = user.Address
            };
        }

        public static UsersManageUsersModel ToManageUsersModel(this User user)
        {
            return new UsersManageUsersModel()
            {
                Id = user.Id,
                Username = user.Username,
               IsAdmin = user.IsAdmin
            };
        }

    }
}
