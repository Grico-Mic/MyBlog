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
    }
}
