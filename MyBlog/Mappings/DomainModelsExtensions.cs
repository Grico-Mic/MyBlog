using MyBlog.Models;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
