using MyBlog.Models;
using System.Collections.Generic;

namespace MyBlog.Servises.Interfaces
{
    public interface IMyBlogsServise
    {
        public List<Blog> GetAll();
        public Blog GetById(int id);
        void Create(Blog blog);
        public List<Blog>GetBlogByTitle(string title);
        void Delete(int id);
        void Update(Blog blog);
    }
}
