using MyBlog.Models;
using MyBlog.Servises.DtoModels;
using System.Collections.Generic;

namespace MyBlog.Servises.Interfaces
{
    public interface IMyBlogsServise
    {
        public List<Blog> GetAll();
        public Blog GetById(int id);
        void Create(Blog blog);
        public List<Blog>GetBlogByTitle(string title);
        StatusModel Delete(int id);
        StatusModel Update(Blog blog);
    }
}
