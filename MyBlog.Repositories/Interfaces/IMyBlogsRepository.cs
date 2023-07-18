using MyBlog.Models;
using System.Collections.Generic;


namespace MyBlog.Repositories.Interfaces
{
    public interface IMyBlogsRepository : IBaseRepository<Blog>
    {
       
        public List<Blog> GetBlogByTitle(string title);
       
    }
}
